using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFacePlayer : MonoBehaviour
{
    public Camera playerCamera;
    // Start is called before the first frame update
    void Start()
    {
        playerCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position + playerCamera.transform.rotation * Vector3.forward, Vector3.up);
    }
}
