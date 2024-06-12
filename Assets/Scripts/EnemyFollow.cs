using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor.Recorder.Input;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour {
    public AudioSource a;
    public NavMeshAgent enemy;
    public Transform Player; 
    public float attackRange;
    public float dps;
    private Animator mAnimator;
    GameObject CameraPlayer;
    bool playerInAttackRange;
    public GameObject EnemyObject;
    float EnemyHealth;
    bool Recovery;

    // Start is called before the first frame update
    void Start() {
        playerInAttackRange = false;
        mAnimator = GetComponent<Animator>();
        CameraPlayer=GameObject.Find("Main Camera");
        Recovery = false;
    }

    // Update is called once per frame
    void Update() {
        UnityEngine.Vector3 distanceToPlayer = transform.position - Player.position;
        EnemyHealth = EnemyObject.GetComponent<Enemy>().EnemyHealth;
        Recovery = EnemyHealth <= 50 && EnemyHealth > 1;

        playerInAttackRange = distanceToPlayer.magnitude < attackRange;
        bool anim = distanceToPlayer.magnitude < (attackRange+1);
        //Debug.Log(playerInAttackRange);
        if(Recovery) RecoveryMode();
        else if(playerInAttackRange) AttackPlayer();
        else ChasePlayer();

        if (anim && !Recovery) Box();
        else Walk();
        //enemy.transform.LookAt(Player);
    }

    private void ChasePlayer() {
        Debug.Log("enemy: " + transform.position);
        Debug.Log("player: " + Player.position);
        enemy.SetDestination(Player.position);
        enemy.isStopped = false;
    }

    private void AttackPlayer() {
        enemy.SetDestination(transform.position);
        enemy.isStopped = true;
    }

    private void RecoveryMode() {
        UnityEngine.Vector3 fleePos = transform.position - Player.position;
        UnityEngine.Vector3.Normalize(fleePos);
        float minSafeDist = 3.0f;
        float newDist = 0.5f;
        UnityEngine.Vector3 randDir = new UnityEngine.Vector3(Random.Range(-10.0f, -2.0f), 0.0f, Random.Range(2.0f,10.0f));
        UnityEngine.Vector3.Normalize(randDir);
        randDir *= newDist;
        fleePos *= minSafeDist;
        UnityEngine.Vector3 finalV3 = randDir + fleePos;
        finalV3.y = transform.position.y;
        Debug.Log("I'm cumming: " + finalV3);
        EnemyObject.GetComponent<Enemy>().EnemyHealth+=(2*Time.deltaTime);
        enemy.SetDestination(finalV3);
    }

    private void Walk(){
        mAnimator.SetBool("WhatToDo", true);
    }

    private void Box(){
        mAnimator.SetBool("WhatToDo", false);
        CameraPlayer.GetComponent<Player>().playerHealth-=dps/100;
        if (!a.isPlaying){
             a.PlayDelayed(1);
        }
    }
}
