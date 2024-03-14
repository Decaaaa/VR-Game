using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        Destroy(this.gameObject);
    }
}
