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
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        PhoneCallTime();
        //agent = GetComponent<NavMeshAgent>();
    }

    public void PhoneCallTime() {
        agent.SetDestination(phoneCallPlace.position);
    }

    public void PhoneCallDone()
    {
        agent.SetDestination(startPosition);
    }
}
