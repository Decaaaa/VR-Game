using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor.Animations;
using UnityEngine;

public class stayUp : MonoBehaviour
{
    public Animator urmum;
        // Update is called once per frame
    void Update()
    {
        //to idle
        // if(transform.position.y < 50.91401f && urmum.GetInteger("newInt") == 3) 
        //     transform.position = new Vector3(transform.position.x, 50.91401f, transform.position.z);
        // if (Math.Abs(transform.position.y-50.06767f)<0.0001f && urmum.GetInteger("newInt") == 2){
        //     urmum.SetInteger("newInt", 3);
        // }
        //to push up
        if(transform.position.y < 50.91401f && urmum.GetInteger("newInt") == 3) 
            transform.position = new Vector3(transform.position.x, 50.91401f, transform.position.z);
        if (Math.Abs(transform.position.y-50.06767f)<0.01f && urmum.GetInteger("newInt") == 2){
            urmum.SetInteger("newInt", 3);
        }
    }
}