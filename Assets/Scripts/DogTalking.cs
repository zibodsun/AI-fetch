using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogTalking : MonoBehaviour
{
    public AudioSource voice;
    public Animator animator;
    public bool isplaying;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (voice.isPlaying && !isplaying) 
        {
            Debug.Log("Dog Talking");
            animator.Play("Talking");
            isplaying = true;
        }
        else if (!voice.isPlaying)
        {
            animator.Play("Idle");
            isplaying = false;
        }
    }
}
