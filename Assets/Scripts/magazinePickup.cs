using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magazinePickup : MonoBehaviour
{

    public string triggeringTag;
    private GameObject Gun;

    public GameObject thisMagazine;
    // public int bulletsToAdd;

    private void Awake()
    {
        // Gun = GameObject.Find("Ak-47 (1)");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("addedBullets " +Gun.GetComponent<WeaponSettings>().bulletNum);
            int bulletsToAdd = 10;
            other.gameObject.GetComponent<WeaponSettings>().addBullet(bulletsToAdd);
            // StartCoroutine(Coroutine());
            Destroy(gameObject);
        }
    }
}
