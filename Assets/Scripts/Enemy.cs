using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float EnemyHealth;
    public float damagetakenpers;
    
    GameObject mc;

    void Start()
    {
        mc = GameObject.Find("Main Camera");
    }
    
    void OnTriggerEnter(Collider other) {
        if(other.tag == "playerContact") {
            //Destroy(this.gameObject);
            EnemyHealth-=damagetakenpers/30;
        }
        if(EnemyHealth <= 0) {
            Destroy(GameObject.Find("Cool Robot Again"));
            Destroy(GameObject.Find("Health Bars"));
        }
        // Vector3 playerPos = mc.transform.position;
        // if(EnemyHealth <= 0 && !((playerPos.x>314.34 && playerPos.x<324.62) && (playerPos.z>-207 && playerPos.z<-202.77))) {
        //     GameObject.Find("Complete XR Origin Set Up Variant").transform.rotation = new Quaternion(0, 180, 0, 0);
        //     GameObject.Find("Complete XR Origin Set Up Variant").transform.position = new Vector3(320 , 51, -208);
        //     GameObject.Find("Main Camera").transform.rotation = new Quaternion(0, 0, 0, 0);
        //     GameObject.Find("Main Camera").transform.position = new Vector3(0, 0, 0);
        // }
    }
}
