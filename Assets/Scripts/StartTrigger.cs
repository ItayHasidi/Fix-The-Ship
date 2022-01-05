
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartTrigger : MonoBehaviour
{
    [SerializeField] string triggeringTag;
    
    public void StartGame()
    {
        SceneManager.LoadScene("Tutorial");
    }
    
}