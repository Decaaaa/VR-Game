using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float EnemyHealth;
    public float damagetakenpers;

    void OnCollisonEnter(Collision col) {
        Debug.Log("NIJNJA Krishna");
        if(col.gameObject.tag.Equals("playerContact")) {
               EnemyHealth-=(System.Math.Abs(col.relativeVelocity.x)+System.Math.Abs(col.relativeVelocity.y)+System.Math.Abs(col.relativeVelocity.z))/1000*damagetakenpers;
        }
    }
}
