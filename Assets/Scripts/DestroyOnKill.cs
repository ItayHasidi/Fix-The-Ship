using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyOnKill : MonoBehaviour
{

    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;
    private void OnTriggerEnter(Collider other) {
        if (other.tag == triggeringTag && enabled) {
            // Destroy(this.gameObject);
            // Destroy(other.gameObject);
            GetComponent<EnemyAiTutorial>().TakeDamage(10);
        }
    }

    private void Update() {
        /* Just to show the enabled checkbox in Editor */
    }
}
