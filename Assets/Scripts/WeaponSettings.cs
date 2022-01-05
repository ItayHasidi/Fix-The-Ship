using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSettings : MonoBehaviour
{

    public int bulletNum = 60;
    public GameObject bulletPrefab;
    public float fireRate = 0.5f;
    public float currentTimeShot = 0f;
    public GameObject bulletPlaceFiring;

    public Text ammo;

    // Start is called before the first frame update
    void Start()
    {
        ammo.text = "Ammo :  " + bulletNum;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (bulletNum > 0)
            {
                Shoot();
            }
        }
    }

    public void addBullet (int bullets)
    {
        bulletNum += bullets;
        ammo.text = "Ammo :  " + bulletNum;
    }

    public void Shoot ()
    {
        Quaternion quatEul = Quaternion.Euler(180, 0, 0);
        GameObject bullet = Instantiate(bulletPrefab, bulletPlaceFiring.transform.position, quatEul);
        Vector3 ScaleBullet = new Vector3(0.1f, 0.1f, 0.1f);
        bullet.transform.localScale = ScaleBullet;
        Rigidbody rbBullet = bullet.GetComponent<Rigidbody>();
        rbBullet.AddForce(transform.forward * 90f, ForceMode.Impulse);
        bulletNum--;
        ammo.text = "Ammo :  " + bulletNum;

    }






}
