using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{

    public GameObject open_door, close_door, textE;
    public string triggeringTag;

    // private bool doorflag;

    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        textE.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        // doorflag = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other){
        if (other.tag == triggeringTag && enabled && Input.GetKeyDown(KeyCode.E))
        {
            // if(textE.activeInHierarchy){
            // textE.SetActive(true);
            // }
            
            // if (Input.GetKeyDown(KeyCode.E))
            // {
                // if(doorflag){
                    // doorflag = false;
                    //GetComponent<PlayerMover>().hasCable = true;
                    audioSource.Play();
                    open_door.SetActive(true);
                    // textE.SetActive(false);
                    close_door.SetActive(false);
                    Destroy(textE);
                // }
                // else{
                //     doorflag = true;
                //     audioSource.Play();
                //     open_door.SetActive(false);
                //     textE.SetActive(true);
                //     close_door.SetActive(true);
                // }
                
                
            // }
        }
    }

    // private void OnTriggerExit(Collider other){
    //     if (other.tag == triggeringTag && enabled)
    //     {
    //         textE.SetActive(false);
    //     }
    // }
}
