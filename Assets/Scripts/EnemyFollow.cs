using System;
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
    public Animator mAnimator;
    GameObject CameraPlayer;
    public bool playerInAttackRange;
    public GameObject EnemyObject;
    float EnemyHealth;
    public bool Recovery;
    UnityEngine.Vector3 randDir;
    // Start is called before the first frame update
    void Start() {
        playerInAttackRange = false;
        CameraPlayer=GameObject.Find("Main Camera");
        Recovery = false;
    }

    // Update is called once per frame
    void Update() {
        UnityEngine.Vector3 distanceToPlayer = transform.position - Player.position;
        EnemyHealth = EnemyObject.GetComponent<Enemy>().EnemyHealth;
        Recovery = EnemyHealth <= 50 && EnemyHealth > 25; 

        playerInAttackRange = Math.Abs(distanceToPlayer.magnitude) < attackRange;
        if(Recovery) RecoveryMode();
        else if(playerInAttackRange) AttackPlayer();
        else ChasePlayer();

        if (playerInAttackRange && !Recovery) Box();
        else Walk();
        //enemy.transform.LookAt(Player);

        if(mAnimator.GetBool("moveBack")) {
            transform.position = transform.position-(Player.position-transform.position)/40;
            mAnimator.SetBool("moveBack", false);
        }
    }

    private void ChasePlayer() {
        //Debug.Log("enemy: " + transform.position);
        //Debug.Log("player: " + Player.position);
        enemy.SetDestination(Player.position);
        enemy.isStopped = false;
    }

    private void AttackPlayer() {
        enemy.SetDestination(transform.position);
        enemy.isStopped = true;
    }

    private void RecoveryMode() {
        enemy.SetDestination(transform.position-(Player.position-transform.position)/100);
        enemy.isStopped = false;
    }

    private void Walk(){
        mAnimator.SetBool("WhatToDo", true);
    }

    private void Box(){
        mAnimator.SetBool("WhatToDo", false);
        if(EnemyHealth <= 25) CameraPlayer.GetComponent<Player>().playerHealth-=dps*Time.deltaTime;
        CameraPlayer.GetComponent<Player>().playerHealth-=dps*Time.deltaTime;
        if (!a.isPlaying){
             a.PlayDelayed(1);
        }
    }
}
