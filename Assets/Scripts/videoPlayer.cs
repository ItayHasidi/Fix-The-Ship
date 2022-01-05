using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class videoPlayer : MonoBehaviour
{
    public VideoPlayer video;
    public string videoFileName;
    public GameObject skipButton;
    // Start is called before the first frame update
    void Start()
    {
        // video.url = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
        
        video.loopPointReached += LoadScene;
    }

    public void playVideo(){
        skipButton.SetActive(true);
        video.Play();
    }
    public void LoadScene(VideoPlayer vp){
        SceneManager.LoadScene(1);
    }
}
