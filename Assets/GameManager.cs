using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;

    public GameObject menu, sight, life, ammo;
    public GameObject winPanel;
    public GameObject lostPanel;
    public GameObject loadingPanel;
    public float TimeSet;
    public int Min;
    public int addZero;
    public Text txtTimer;

    private bool isGamePaused;
    // Start is called before the first frame update
    void Start()
    {
        isGamePaused = false; 
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        txtTimer.text = "" + Min + ":00";
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!isGamePaused) {
                ShowMenu();
            } else {
                HideMenu();
            }
        }
    }
    
    public void ShowMenu(){
        Time.timeScale = 0;
        // player.GetComponent<PlayerMover>().enabled = false;
        isGamePaused = true;
        menu.SetActive(true);
        sight.SetActive(false);
        life.SetActive(false);
        ammo.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
    }
    public void HideMenu(){
        Time.timeScale = 1;
        // player.GetComponent<PlayerMover>().enabled = true;
        isGamePaused = false;
        menu.SetActive(false);
        sight.SetActive(true);
        life.SetActive(true);
        ammo.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(Min <= 0 && TimeSet <= 0)
        {
            txtTimer.text = Min + ":" + 00;

            SetLostPanel();
        }
        else
        {
            if(TimeSet > 0)
            {
                TimeSet -= Time.fixedDeltaTime;
            }
            else
            {
                Min -= 1;
                TimeSet = 60f;
            }
            txtTimer.text = Min + ":" +TimeSet;
        }
    }
    public void RestartScene()
    {
        Destroy(player);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameObject SDAS = GameObject.Find("GameManager");
    }
    public void SetLostPanel()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        lostPanel.SetActive(true);
    }
    public void SetWinPanel()
    {
        
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        winPanel.SetActive(true);
    }

    public void StartTutorial(){
        SceneManager.LoadScene("Tutorial");
    }

    public void SetLevel1()
    {
        Destroy(player);
        Time.timeScale = 0;
        // Cursor.lockState = CursorLockMode.None;
        // Cursor.visible = true;
        loadingPanel.SetActive(true);
        SceneManager.LoadScene("Level1_test");
    }

    public void SetLevel2()
    {
        Destroy(player);
        Time.timeScale = 0;
        // Cursor.lockState = CursorLockMode.None;
        // Cursor.visible = true;
        loadingPanel.SetActive(true);
        SceneManager.LoadScene("Level2");
    }

}
