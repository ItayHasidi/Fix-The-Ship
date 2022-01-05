using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeObject : MonoBehaviour
{

    public GameObject objectToShow, objectToRemove1, objectToRemove2;
    public GameObject Player;
    public string triggeringTag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other){
        if (other.tag == triggeringTag && enabled)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                AudioSource audioSource = GetComponent<AudioSource>();
                //GetComponent<PlayerMover>().hasCable = true;
                audioSource.Play();
                objectToShow.SetActive(true);
                objectToRemove1.SetActive(false);
                objectToRemove2.SetActive(false);
                Player.GetComponent<PlayerMover>().hasCable = true;
                
            }
        }
    }
}
