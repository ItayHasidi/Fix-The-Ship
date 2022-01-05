using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoolTrigger : MonoBehaviour
{
    [Tooltip("Answer should be true or false")]
    [SerializeField] bool answer;
    [SerializeField] GameObject textObj;
    [SerializeField] GameObject[] ObjectsToDestroy;
    
    private void OnTriggerEnter(Collider other) {
        TextMeshPro textA = textObj.GetComponent<TextMeshPro>();
        if(answer){
            textA.text = "true";
            
        }
        else
            textA.text = "false";
        
        for(int i = 0; i < ObjectsToDestroy.Length; i++){
            Destroy(ObjectsToDestroy[i]);
        }    
    }
}
