using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandStuff : MonoBehaviour
{   
    public Vector3 prevPosition;
    public float velocity;
    // Start is called before the first frame update
    void Start()
    {
        prevPosition = transform.position;
        velocity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = Math.Abs((transform.position-prevPosition).magnitude/Time.deltaTime);
        prevPosition = transform.position; 
        //Debug.Log(velocity);
    }
}
