using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickUp : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;
    public GameObject spotLight;
    public GameObject TxtE;




    private void OnTriggerStay(Collider other) {

            if (other.tag == triggeringTag && enabled)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                Animator animator = GameObject.Find("Player").GetComponent<Animator>();
                animator.SetBool("hasRifle", true);
                PlayerMover plMover = other.gameObject.GetComponent<PlayerMover>();
                plMover.ammo.enabled = true;
                gameObject.transform.SetParent(plMover.gunHolderRef.transform);
                GetComponent<BoxCollider>().enabled = false;
                GetComponent<WeaponSettings>().ammo = plMover.ammo;
                GetComponent<WeaponSettings>().enabled = true;
                Vector3 vcPos = new Vector3(0.177f,-0.021f,-0.344f);
                gameObject.transform.localPosition = vcPos;
                Quaternion QuatRot = Quaternion.Euler(0.557995915f,67.1999969f,0f);
                gameObject.transform.localRotation = QuatRot;
                spotLight.gameObject.SetActive(false);
                TxtE.gameObject.SetActive(false);
                GetComponent<BoxCollider>().enabled = false;
                this.enabled = false;
                }
        }
    }
    void Update()
    {
        
    }
}
