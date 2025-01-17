﻿using UnityEngine;


/**
 * This component lets the player show/hide the cursor by clicking ESC.
 * Initially, it hides the cursor.
 */
public class CursorHider : MonoBehaviour {
    void Start() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!Cursor.visible) {
                Show();
            } else {
                Hide();
            }
        }
    }
    public void Hide(){
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Show(){
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
