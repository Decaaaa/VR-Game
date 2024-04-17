using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float EnemyHealth;
    public float damagetakenpers;
    public GameObject player;
    private bool debug = true;
    
    void OnTriggerEnter(Collider other) {
        if(other.tag == "playerContact") {
            //Destroy(this.gameObject);
            EnemyHealth-=damagetakenpers/30;
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
        if(debug) {
            EnemyHealth -= 10 * Time.deltaTime;
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
    }
}
