using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float EnemyHealth;
    public float damagetakenpers;

    void OnCollisonEnter(Collision col) {
        if(col.gameObject.name == "hands_coll:b_r_index1" ||
            col.gameObject.name == "hands_coll:b_r_index2" ||
            col.gameObject.name == "hands_coll:b_r_index3" ||
            col.gameObject.name == "hands_coll:b_r_middle1" ||
            col.gameObject.name == "hands_coll:b_r_middle2" ||
            col.gameObject.name == "hands_coll:b_r_middle3" ||
            col.gameObject.name == "hands_coll:b_r_ring1" ||
            col.gameObject.name == "hands_coll:b_r_ring2" ||
            col.gameObject.name == "hands_coll:b_r_ring3" ||
            col.gameObject.name == "hands_coll:b_r_pinky1" ||
            col.gameObject.name == "hands_coll:b_r_pinky2" ||
            col.gameObject.name == "hands_coll:b_r_pinky3" ||
            col.gameObject.name == "hands_coll:b_r_thumb1" ||
            col.gameObject.name == "hands_coll:b_r_thumb2" ||
            col.gameObject.name == "hands_coll:b_r_thumb3" ||
            col.gameObject.name == "hands_coll:b_l_index1" ||
            col.gameObject.name == "hands_coll:b_l_index2" ||
            col.gameObject.name == "hands_coll:b_l_index3" ||
            col.gameObject.name == "hands_coll:b_l_middle1" ||
            col.gameObject.name == "hands_coll:b_l_middle2" ||
            col.gameObject.name == "hands_coll:b_l_middle3" ||
            col.gameObject.name == "hands_coll:b_l_ring1" ||
            col.gameObject.name == "hands_coll:b_l_ring2" ||
            col.gameObject.name == "hands_coll:b_l_ring3" ||
            col.gameObject.name == "hands_coll:b_l_pinky1" ||
            col.gameObject.name == "hands_coll:b_l_pinky2" ||
            col.gameObject.name == "hands_coll:b_l_pinky3" ||
            col.gameObject.name == "hands_coll:b_l_thumb1" ||
            col.gameObject.name == "hands_coll:b_l_thumb2" ||
            col.gameObject.name == "hands_coll:b_l_thumb3") {
               EnemyHealth-=(System.Math.Abs(col.relativeVelocity.x)+System.Math.Abs(col.relativeVelocity.y)+System.Math.Abs(col.relativeVelocity.z))/1000*damagetakenpers;
        }
    }
}
