using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float EnemyHealth;
    public float damagetakenpers;
    public float damageHealedPerSec;
    public GameObject player;
    public hapticsa Haptics;
    private bool debug = false;
    
    void OnTriggerEnter(Collider other) {
        if(other.tag == "playerContactR") {
            //Destroy(this.gameObject);
            EnemyHealth-=damagetakenpers*Time.deltaTime;
            Haptics.isHapticR = true;
        }
        if(other.tag == "playerContactL") {
            //Destroy(this.gameObject);
            EnemyHealth-=damagetakenpers*Time.deltaTime;
            Haptics.isHapticL = true;
        }
        if(EnemyHealth <= 0) {
            Destroy(GameObject.Find("Cool Robot Again"));
            Destroy(GameObject.Find("Health Bars"));
        }
        Vector3 playerPos = player.transform.position;
        if(EnemyHealth <= 0 && !((playerPos.x>399.63f && playerPos.x<404.15f) && (playerPos.z>-4.07f && playerPos.z<10.26f))) {
            player.transform.position = new Vector3(401.96f , 51, 6.81f);
            player.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    void Update() {
        // if(debug) {
        //     EnemyHealth -= 10 * Time.deltaTime;
        //     if(EnemyHealth <= 0) {
        //         Destroy(GameObject.Find("Cool Robot Again"));
        //         Destroy(GameObject.Find("Health Bars"));
        //     }
        //     Vector3 playerPos = player.transform.position;
        //     if(EnemyHealth <= 0 && !((playerPos.x>399.63f && playerPos.x<404.15f) && (playerPos.z>-4.07f && playerPos.z<10.26f))) {
        //         player.transform.position = new Vector3(401.96f , 51, 6.81f);
        //         player.transform.rotation = Quaternion.Euler(0, 180, 0);
        //     }
        // }
        //Debug.Log(EnemyHealth <= 50 && EnemyHealth > 25);
        if(EnemyHealth <= 50 && EnemyHealth > 25) EnemyHealth += damageHealedPerSec * Time.deltaTime;
        Haptics.isHapticL=false;
        Haptics.isHapticR=false;
    }
}
