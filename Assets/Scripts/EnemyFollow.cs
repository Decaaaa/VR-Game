using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour {

    private Animator mAnimator;

    public AudioSource a;

    public NavMeshAgent enemy;
    public Transform Player; 

    //State
    public float attackRange;
    bool playerInAttackRange;

    public float dps;
    GameObject CameraPlayer;


    // Start is called before the first frame update
    void Start() {
        playerInAttackRange = false;
        mAnimator = GetComponent<Animator>();
        CameraPlayer=GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update() {
        Vector3 distanceToPlayer = transform.position - Player.position;

        playerInAttackRange = (distanceToPlayer.magnitude < attackRange);
        bool anim = (distanceToPlayer.magnitude < (attackRange+1));
        
        if (playerInAttackRange) AttackPlayer();
        else ChasePlayer();

        if (anim) Box();
        else Walk();
        //enemy.transform.LookAt(Player);
    }

    private void ChasePlayer() {
        enemy.SetDestination(Player.position);
    }

    private void AttackPlayer() {
        enemy.SetDestination(transform.position);
        
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
