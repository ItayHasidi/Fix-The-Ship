
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndTrigger : MonoBehaviour
{
    [SerializeField] string triggeringTag;
    
    void OnTriggerEnter(Collider other)
    {
        if(triggeringTag == other.tag)
        {
            GameObject gm = GameObject.Find("GameManager");
            gm.GetComponent<GameManager>().SetLevel2();
        }
    }
    
}