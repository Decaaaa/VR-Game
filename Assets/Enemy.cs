using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float EnemyHealth;
    public float damagetakenpers;

    void OnTriggerEnter(Collider other) {
        if(other.tag == "playerContact") {
            Destroy(this.gameObject);
            //EnemyHealth-=10*damagetakenpers;
        }
    }
}
