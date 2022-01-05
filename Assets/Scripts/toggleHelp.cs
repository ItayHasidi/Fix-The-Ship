using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleHelp : MonoBehaviour
{
    public GameObject panel;
    private bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeState(){
        if(!isActive){
            panel.SetActive(true);
            isActive = true;
        }
        else{
            panel.SetActive(false);
            isActive = false;
        }
    }
}
