using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class openQuestion3 : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;
    public GameObject noItemsPanel, player;
    public GameObject drill, wrench, screws, endMsg, winPanel;
    Toggle toggle;

    // private bool isPanelShown = false;

    private void OnTriggerStay(Collider other) {

        if (other.tag == triggeringTag && enabled)
        {
            if(!drill.activeInHierarchy || !wrench.activeInHierarchy || !screws.activeInHierarchy){
                noItemsPanel.SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                // Time.timeScale = 0;
                drill.SetActive(false);
                wrench.SetActive(false);
                screws.SetActive(false);
                gameObject.GetComponent<BoxCollider>().enabled = false;   
                endMsg.SetActive(true);
                AudioSource audioSource = GetComponent<AudioSource>();
                audioSource.Play();  
                winPanel.SetActive(true);        
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if(!drill.activeInHierarchy || !wrench.activeInHierarchy || !screws.activeInHierarchy){
                noItemsPanel.SetActive(false);
            }
        // else if (other.tag == triggeringTag && enabled)
        // { 
        //     Time.timeScale = 1;
        //     Cursor.visible = false;
        //     Cursor.lockState = CursorLockMode.Locked;
        // }
    }
}
