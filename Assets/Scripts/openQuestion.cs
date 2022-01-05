using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openQuestion : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;
    public GameObject trueAns, falseAns;
    public GameObject open_door, close_door;
    // public GameObject btn1, btn2, btn3, btn4, qText, pic;
    public GameObject panel;
    // private bool isPanelShown = false;

    private void OnTriggerStay(Collider other) {

            if (other.tag == triggeringTag && enabled)
            {
                // Debug.Log(Input.GetKeyDown(KeyCode.E)+" = key E");

                if (Input.GetKeyDown(KeyCode.E))
                {
                    // isPanelShown = true;
                    Time.timeScale = 0;
                    panel.SetActive(true);
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    // GetComponent<CursorHider>().Show();
                    // btn1.SetActive(true);
                    // btn2.SetActive(true);
                    // btn3.SetActive(true);
                    // btn4.SetActive(true);
                    // qText.SetActive(true);
                    // pic.SetActive(true);
                    
                }
        }
    }

    private void OnTriggerExit(Collider other) {

            if (other.tag == triggeringTag && enabled)
            { 
                // isPanelShown = false;
                Time.timeScale = 1;
                panel.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                // GetComponent<CursorHider>().Hide();
                // btn1.SetActive(false);
                // btn2.SetActive(false);
                // btn3.SetActive(false);
                // btn4.SetActive(false);
                // qText.SetActive(false);
                // pic.SetActive(false); 
        }
    }
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Escape)) {
        //     if (isPanelShown) {
        //         cursorHider.Show();
        //     } else {
        //         panel.SetActive(false);
        //         cursorHider.Hide();
        //     }
        // }
    }

    
    public void TrueAns() {
        falseAns.SetActive(false);
        trueAns.SetActive(true);
        open_door.SetActive(true);
        close_door.SetActive(false);
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        // panel.SetActive(false);

        Time.timeScale = 1;
        panel.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void FalseAns() {
        falseAns.SetActive(true);
    }
}
