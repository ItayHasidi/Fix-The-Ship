using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



/**
 *  This component allows the player to add force to its object using the arrow keys.
 *  Works with a 3D RigidBody.
 */
// [RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(TouchDetector))]


public class PlayerMover : MonoBehaviour {
    private TouchDetector td;
    public GameObject gunHolderRef;

    public Text ammo;
    public Image health;

    public float currentHealth;
    public float maxHelath;

    public bool ProccedCollision = false;

    public float WeaponAngle;

    public bool hasCable;
    void Start() {
        td = GetComponent<TouchDetector>();
        currentHealth = maxHelath;
        hasCable = false;

        // AudioSource audioSource = GetComponent<AudioSource>();
        // audioSource.Play();

    }
    [SerializeField]
    float stepSize = 1f;

    private void Update() {
        // Keyboard events are tested each frame, so we should check them here.
        if (Input.GetKeyDown(KeyCode.Space)){
            // playerWantsToJump = true;
        }
        RotateWeapon(gunHolderRef);


    }

    public void playerHitted(float setDamage)
    {
        if(currentHealth < 0)
        {
            GameObject GameManager = GameObject.Find("GameManager");
            GameManager gameManagerScript = GameManager.GetComponent<GameManager>();
            gameManagerScript.SetLostPanel();
        }
        currentHealth -= setDamage;
        health.fillAmount = currentHealth * 0.01f;
        
    }
    public void RotateWeapon(GameObject weapon)
    {
        float mouseY = Input.GetAxis("Mouse Y");
        Vector3 rotation = weapon.transform.localEulerAngles;
        rotation.x += mouseY * -0.35f;  // Rotation around the vertical (Y) axis
        weapon.transform.localEulerAngles = rotation;
    }
    
}
