using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPickup : MonoBehaviour
{

    public string triggeringTag;
    public GameObject Player;

    public GameObject thisHealth;

    [Tooltip("a number between 0 and 1")] [SerializeField]
    float healthToAdd;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == triggeringTag)
        {
            Debug.Log("added health "+healthToAdd);
            Player.GetComponent<PlayerMover>().currentHealth += healthToAdd;
            Debug.Log("player health "+Player.GetComponent<PlayerMover>().currentHealth);
            thisHealth.SetActive(false);
        }
    }
}