using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magazineRotator : MonoBehaviour
{
private float rotY, escY;
    public float RotationSpeed = 90f;
    public bool ClockWiseRotation;

    public float xRotation;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(ClockWiseRotation == false)
        {
            rotY += Time.deltaTime * RotationSpeed;
        }
        else
        {
            rotY += -Time.deltaTime * RotationSpeed;
        }
        transform.rotation = Quaternion.Euler(xRotation,rotY, 0);        
    }
}
