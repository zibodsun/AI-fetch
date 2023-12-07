using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Yarn.Unity;

public class OwnerBehaviour : MonoBehaviour
{
    public Transform phoneCallPlace;

    private Vector3 startPosition;
    public NavMeshAgent agent;

    bool onPhone;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        
        //agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (onPhone)
        {
            agent.SetDestination(phoneCallPlace.position);
        }
        else {
            agent.SetDestination(startPosition);
        }
        //
    }
    public void PhoneCallTime() {
        onPhone = true;
        GetComponent<BoxCollider>().enabled = false;
    }

    public void PhoneCallDone()
    {
        onPhone = false;
        GetComponent<BoxCollider>().enabled = true;
    }


}
