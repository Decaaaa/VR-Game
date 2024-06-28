using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float EnemyHealth;
    public float damagetakenpers;
    public float damageHealedPerSec;
    public GameObject player;
    public hapticsa Haptics;
    private bool debug = false;
    
    public GameObject rightHand;
    public GameObject leftHand;
    public GameObject leftLeg;
    public GameObject rightLeg;
    public GameObject label;
    public float maxHitStrength;

    private Rigidbody rb;
    
    public Animator urmum;

    public AudioSource[] audios;
    void Start(){
        EnemyHealth = GameObject.Find("MaxHealth Backup").GetComponent<MaxHealth>().getEnemyHealth();
        rb=GetComponent<Rigidbody>();
        GameObject.Find("MaxHealth Backup").GetComponent<MaxHealth>().printTime();
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag == "playerContactR") {
            //Destroy(this.gameObject);
            float v=rightHand.GetComponent<HandStuff>().velocity;
            if(v > 1) {
                EnemyHealth-=damagetakenpers*v*Time.deltaTime;
                Haptics.SendHapticsR(v);
                label.GetComponent<updateForceText>().updateText(v);
                if(maxHitStrength < v) maxHitStrength = v;
                if(10/v <= 1) {
                    urmum.SetBool("Knockback", true);
                    urmum.SetBool("leftHit", false);
                }
                else {
                    if(Random.Range(0,10/v) <= 2 && (int) Random.Range(0,2.999999999999f) == 1) {
                        urmum.SetBool("Knockback", true);
                        urmum.SetBool("leftHit", false);
                    }
                }
                if(!audios[0].isPlaying && !audios[1].isPlaying && !audios[2].isPlaying && !audios[3].isPlaying && !audios[4].isPlaying)
                    audios[(int) Random.Range(0,4.999f)].PlayDelayed(0);
            }
        }

        if(other.tag == "playerContactL") {
            //Destroy(this.gameObject);
            float v=leftHand.GetComponent<HandStuff>().velocity;
            if(v > 1) {
                EnemyHealth-=damagetakenpers*v*Time.deltaTime;
                Haptics.SendHapticsL(v);
                label.GetComponent<updateForceText>().updateText(v);
                if(maxHitStrength < v) maxHitStrength = v;
                if(10/v <= 1) {
                    urmum.SetBool("Knockback", true);
                    urmum.SetBool("leftHit", true);
                }
                else {
                    if(Random.Range(0,10/v) <= 2 && Random.Range(0,100) < 50) {
                        urmum.SetBool("Knockback", true);
                        urmum.SetBool("leftHit", true);
                    }
                }
                audios[(int) Random.Range(0,4.999f)].PlayDelayed(0);
            }
        }

        if (other.tag == "kickContactR")
        {
            //Destroy(this.gameObject);
            float v = rightLeg.GetComponent<HandStuff>().velocity;
            if (v > 1)
            {
                EnemyHealth -= damagetakenpers * v * Time.deltaTime;
                Haptics.SendHapticsR(v);
                label.GetComponent<updateForceText>().updateText(v);
                if (maxHitStrength < v) maxHitStrength = v;
                if (10 / v <= 1)
                {
                    urmum.SetBool("Knockback", true);
                    urmum.SetBool("leftHit", false);
                }
                else
                {
                    if (Random.Range(0, 10 / v) <= 2 && (int)Random.Range(0, 2.999999999999f) == 1)
                    {
                        urmum.SetBool("Knockback", true);
                        urmum.SetBool("leftHit", false);
                    }
                }
                if (!audios[0].isPlaying && !audios[1].isPlaying && !audios[2].isPlaying && !audios[3].isPlaying && !audios[4].isPlaying)
                    audios[(int)Random.Range(0, 4.999f)].PlayDelayed(0);
            }
        }

        if (other.tag == "kickContactL")
        {
            //Destroy(this.gameObject);
            float v = leftLeg.GetComponent<HandStuff>().velocity;
            if (v > 1)
            {
                EnemyHealth -= damagetakenpers * v * Time.deltaTime;
                Haptics.SendHapticsL(v);
                label.GetComponent<updateForceText>().updateText(v);
                if (maxHitStrength < v) maxHitStrength = v;
                if (10 / v <= 1)
                {
                    urmum.SetBool("Knockback", true);
                    urmum.SetBool("leftHit", true);
                }
                else
                {
                    if (Random.Range(0, 10 / v) <= 2 && Random.Range(0, 100) < 50)
                    {
                        urmum.SetBool("Knockback", true);
                        urmum.SetBool("leftHit", true);
                    }
                }
                audios[(int)Random.Range(0, 4.999f)].PlayDelayed(0);
            }
        }


        if (EnemyHealth <= 0) {
            Destroy(GameObject.Find("Cool Robot Again"));
            Destroy(GameObject.Find("Health Bars"));
        }
        UnityEngine.Vector3 playerPos = player.transform.position;
        if(EnemyHealth <= 0 && !((playerPos.x>399.63f && playerPos.x<404.15f) && (playerPos.z>-4.07f && playerPos.z<10.26f))) {
            player.transform.position = new UnityEngine.Vector3(401.96f , 51, 6.81f);
            player.transform.rotation = UnityEngine.Quaternion.Euler(0, 180, 0);
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
    }
}
