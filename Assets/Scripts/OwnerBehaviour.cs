using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Yarn.Unity;

public class OwnerBehaviour : MonoBehaviour
{
    public Transform phoneCallPlace;

    private Vector3 startPosition;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        agent = GetComponent<NavMeshAgent>();
    }

    [YarnCommand("PhoneCallTime")]
    public void PhoneCallTime() {
        agent.SetDestination(phoneCallPlace.position);
    }

    [YarnCommand("PhoneCallDone")]
    public void PhoneCallDone()
    {
        agent.SetDestination(startPosition);
    }
}
