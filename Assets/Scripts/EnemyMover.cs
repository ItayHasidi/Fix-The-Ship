using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
[Tooltip("The points between which the platform moves")]
    [SerializeField] Transform startPoint = null, endPoint = null;

    [SerializeField] float speed = 1f;

    private bool moveFromStartToEnd = true;

    private Rigidbody rb;
    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        if (moveFromStartToEnd) {
            rb.MovePosition(Vector3.MoveTowards(transform.position, endPoint.position, speed * Time.deltaTime));
        } else {  // move from end to start
            rb.MovePosition(Vector3.MoveTowards(transform.position, startPoint.position, speed * Time.deltaTime));
        }

        if (transform.position == startPoint.position) {
            moveFromStartToEnd = true;
        } else if (transform.position == endPoint.position) {
            moveFromStartToEnd = false;
        }
    }
}
