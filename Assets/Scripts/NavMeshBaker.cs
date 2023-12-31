using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using Unity.AI.Navigation;
using UnityEngine.AI;

public class NavMeshBaker : MonoBehaviour
{
    public ARPlaneManager planeManager;
    public Transform player;
    public NavMeshAgent agent;
    public NavMeshAgent agent1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach (var plane in planeManager.trackables)
        {
            if (plane.transform.position.y < 0.1)
            {
                plane.GetComponent<NavMeshSurface>().BuildNavMesh();
                agent.enabled = true;
                agent1.enabled = true;
            }
        }
    }
}