using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAndHitPlayer : MonoBehaviour
{
    public bool ProcessCollision = false;
    public GameObject bloodExplode;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
       // if(other.gameObject.tag == "Player" && ProcessCollision == false)
       // {
       //     //
 
       //     //
       //     other.GetComponent<PlayerMover>().playerHitted(10f);
       //         Debug.Log("playeIsHit00");
       //     GameObject ps = Instantiate(bloodExplode, other.transform.position, other.transform.rotation.normalized);
       //     Vector3 scale = new Vector3(0.6f, 0.6f, 0.6f);
       //     ps.transform.localScale = scale;
       //     ProcessCollision = true;
       //     Destroy(this.gameObject);
       // }
       //if(other.gameObject.tag == "Enemy" && ProcessCollision == false)
       // {
       //     //other.GetComponent<PlayerMover>().playerHitted(10f);
       //     //GameObject parent = other.transform.parent.gameObject;
       //     other.gameObject.GetComponent<EnemyAiTutorial>().TakeDamage(20);
       //     Debug.Log("EnemyHit");
       //    GameObject ps = Instantiate(bloodExplode, other.transform.position, other.transform.rotation.normalized);
       //     Vector3 scale = new Vector3(0.6f, 0.6f, 0.6f);
       //     ps.transform.localScale = scale;
       //     ProcessCollision = true;
       //     Destroy(this.gameObject);


       // }
       // else
       // {
       //     Destroy(this.gameObject);
       //     //Destroy(this.gameObject);
       // }
    }
    private void OnCollisionEnter(Collision collision)
    {
        SetCollision(collision);
    }
    public void SetCollision(Collision other)
    {
        if (other.gameObject.tag == "Player" && ProcessCollision == false)
        {
            //
            Vector3 colPoint = other.GetContact(0).point;
            Vector3 NormalizeColPoint = colPoint.normalized;
            //
            other.gameObject.GetComponent<PlayerMover>().playerHitted(50f);
            Debug.Log("playeIsHit00");
            GameObject ps = Instantiate(bloodExplode, colPoint, other.transform.rotation.normalized);
            Vector3 scale = new Vector3(0.6f, 0.6f, 0.6f);
            ps.transform.localScale = scale;
            ProcessCollision = true;
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Enemy" && ProcessCollision == false)
        {
            //other.GetComponent<PlayerMover>().playerHitted(10f);
            //GameObject parent = other.transform.parent.gameObject;
            Vector3 colPoint = other.GetContact(0).point;
            Vector3 NormalizeColPoint = colPoint.normalized;
            other.gameObject.GetComponent<EnemyAiTutorial>().TakeDamage(20);
            Debug.Log("EnemyHit");
            GameObject ps = Instantiate(bloodExplode, colPoint, other.transform.rotation.normalized);
            Vector3 scale = new Vector3(0.6f, 0.6f, 0.6f);
            ps.transform.localScale = scale;
            ProcessCollision = true;
            Destroy(this.gameObject);


        }
        else
        {
            Destroy(this.gameObject);
            //Destroy(this.gameObject);
        }
    }    
}
