using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    Vector3 startPosition;
    public Material defaultMaterial;
    public Material fetchableMaterial;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Fetchable")
        {
            GetComponent<MeshRenderer>().material = fetchableMaterial;
        }
        else {
            GetComponent<MeshRenderer>().material = defaultMaterial;
        }
        if (transform.position.y < -10) {
            transform.position = startPosition;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameObject.tag = "Untagged";
        }
    }
}
