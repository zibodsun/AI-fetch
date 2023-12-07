using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class YarnCommandHolder : MonoBehaviour
{
    public GameObject apple;
    public GameObject bone;
    public GameObject eggplant;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void BuyApple() { 
        apple.SetActive(true);
    }

    void BuyBone() { 
        bone.SetActive(true);
    }

    void BuyEggplant() { 
        eggplant.SetActive(true);
    }
}
