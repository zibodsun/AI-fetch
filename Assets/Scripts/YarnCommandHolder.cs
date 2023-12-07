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

    [YarnCommand("Buy_Apple")] 
    public void BuyApple() { 
        apple.SetActive(true);
    }

    [YarnCommand("Buy_Bone")]
    public void BuyBone() { 
        bone.SetActive(true);
    }

    [YarnCommand("Buy_Eggplant")]
    public void BuyEggplant() { 
        eggplant.SetActive(true);
    }
}
