using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject closedDoor;
    public GameObject openedDoor;
     public GameObject btn1, btn2, btn3, btn4, qText, pic;

    public void OnClick() {
            Debug.Log("true answer!");
             Cursor.visible = false;
            Cursor.lockState = CursorLockMode.None;
            btn1.SetActive(false);
            btn2.SetActive(false);
            btn3.SetActive(false);
            btn4.SetActive(false);
            qText.SetActive(false);
            pic.SetActive(false); 
            closedDoor.SetActive(false);
            openedDoor.SetActive(true);
           
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
