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

    private Vector3 targetPosition;

    private float _waitTime;
    private float _waitTimer;
    public float wanderDistance;
    // Start is called before the first frame update
    void Start()
    {
        _waitTime = 5f;
        patienceCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.enabled == false)
            return;

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

                if (Vector3.Distance(fetchItem.transform.position, transform.position) <= 0.05 &&
                    fetchItem.GetComponent<Rigidbody>().velocity.magnitude <= 0.05)
                {
                    if (fetchItem.GetComponent<BallBehaviour>().tasty) { 
                        happy = true;
                    }

                    Destroy(fetchItem);
                    dogCollider.enabled = true;
                    agent.speed = 0.0f;
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
