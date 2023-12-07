using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Yarn.Unity;

public class RandomNavMeshPosition : MonoBehaviour
{
    public InMemoryVariableStorage yarnInMemoryStorage;
    public NavMeshAgent agent;
    public bool isFetcher;
    public Collider dogCollider;
    public Transform playerTransform;
    public bool happy;
    private int patienceCounter;
    public OwnerBehaviour owner;

    private Vector3 targetPosition;

    private float _waitTime;
    private float _waitTimer;
    public float wanderDistance;
    // Start is called before the first frame update
    void Start()
    {
        _waitTime = 5f;
        patienceCounter = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.enabled == false)
            return;

        // owner comes back
        if (patienceCounter == 0) {
            owner.PhoneCallDone();
            if (happy)
            {
                yarnInMemoryStorage.SetValue("$happy", true);
            }
            else {
                yarnInMemoryStorage.SetValue("$sad", true);
            }

        }

        if (_waitTimer < _waitTime)
        {
            _waitTimer += Time.deltaTime;
        }
        else if (isFetcher) 
        {
            GameObject fetchItem = GameObject.FindWithTag("Fetchable");
            if (fetchItem != null)
            {
                agent.SetDestination(fetchItem.transform.position);

                if (Vector3.Distance(fetchItem.transform.position, transform.position) <= 0.1 &&
                    fetchItem.GetComponent<Rigidbody>().velocity.magnitude <= 0.1)
                {
                    if (fetchItem.GetComponent<BallBehaviour>().tasty) { 
                        happy = true;
                        patienceCounter = 0;
                    }

                    Destroy(fetchItem);
                    dogCollider.enabled = true;
                    patienceCounter--;
                }

            }
            // else {
            //    agent.SetDestination(playerTransform.position + new Vector3(0.5f, 0, 0.5f));
            // }
        }
        else
        {
            Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * wanderDistance;

            randomDirection += transform.position;

            NavMeshHit navHit;

            NavMesh.SamplePosition(randomDirection, out navHit, wanderDistance, NavMesh.AllAreas);

            targetPosition = navHit.position;

            agent.SetDestination(targetPosition);

            _waitTimer = 0f;
        }
    }
}
