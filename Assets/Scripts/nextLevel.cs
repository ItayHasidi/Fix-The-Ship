using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextLevel : MonoBehaviour
{
    [SerializeField] string triggeringTag;
    
    void OnTriggerEnter(Collider other)
    {
        if(triggeringTag == other.tag)
        {
            GameObject gm = GameObject.Find("GameManager");
            gm.GetComponent<GameManager>().SetLevel1();
        }
    }
}
