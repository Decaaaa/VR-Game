using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkoutDetection : MonoBehaviour
{
    private bool squats = false;
    private bool jacks = false;

    public Transform head;
    public Transform leftHand;
    public Transform rightHand;
    public int numPoints = 10;

    public GameObject Player;

    private float deltaHead = 0f;
    private float deltaRight = 0f;
    private float deltaLeft = 0f;

    private float oldHeadHeight;
    private float oldRightHeight;
    private float oldLeftHeight;

    private int headDown = 0;
    private int rightDown = 0;
    private int leftDown = 0;

    private int headUp = 0;
    private int rightUp = 0;
    private int leftUp = 0;

    private bool startedSquat = false;
    private bool finishedSquat = false;
    private bool prevSquat = false;
    public int squatCount = 0;

    private bool startedJJ = false;
    private bool finishedJJ = false;
    private bool prevJJ = false;
    public int JJCount = 0;

    private float time = 0f;

    private float playerHeight;
    private bool jumped = false;
    private float dist;
    private float oldDist;
    private float deltaDist;
    private int distIncrease = 0;
    private int distDecrease = 0;
    private bool JJBool = false;

    // Start is called before the first frame update
    void Start()
    {
        oldHeadHeight = head.position.y;
        oldRightHeight = rightHand.position.y;
        oldLeftHeight = leftHand.position.y;

        playerHeight = head.position.y;
        dist = Vector3.Magnitude(rightHand.position - leftHand.position);
        oldDist = dist;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        dist = Vector3.Magnitude(rightHand.position - leftHand.position);
        deltaDist = Math.Abs(dist) - Math.Abs(oldDist);

        UpdateVariables();
        TrackSquats();
        TrackJJ();
        if (finishedSquat && !prevSquat)
        {
            squatCount++;
            Player.GetComponent<MaxHealth>().updateHealth(10);
        }

        if (finishedJJ && !prevJJ && JJBool)
        {
            JJCount++;
            jumped = false;
            Player.GetComponent<MaxHealth>().updateHealth(10);
        }

        //Debug.Log("squats: " + squatCount + "\nhealth: " + Player.GetComponent<MaxHealth>().getHealth());

        Debug.Log("JJ: " + JJCount + " | Squat: " + squatCount);
        prevSquat = finishedSquat;
        prevJJ = finishedJJ;
        oldDist = dist;
    }

    void TrackSquats()
    {
        if (headDown > 90 && headDown > headUp)
        {
            startedSquat = true;
            finishedSquat = false;
        }

        if(startedSquat)
        {
            if(headUp > 30)
            {
                startedSquat = false;
                finishedSquat = true;
            }
        }
    }

    void TrackJJ()
    {   
        if(head.position.y - playerHeight >= 0.17) {
            if (leftUp > 25 && leftUp > leftDown)
            {
                startedJJ = true;
                finishedJJ = false;
            }

            if(startedJJ) {
                if(leftDown > 25) {
                    finishedJJ = true;
                    startedJJ = false;
                }
            }

            if(distIncrease > 15) {
                JJBool = true;
            }

            if(distDecrease > 15) {
                JJBool = false;
            }
        }
    }

    void UpdateVariables()
    {
        deltaHead = head.position.y - oldHeadHeight;
        deltaRight = rightHand.position.y - oldRightHeight;
        deltaLeft = leftHand.position.y - oldLeftHeight;

        if (deltaHead < 0)
        {
            headDown++;
        }
        else
        {
            headDown = 0;
        }

        if (deltaRight < 0)
        {
            rightDown++;
        }
        else
        {
            rightDown = 0;
        }

        if (deltaLeft < 0)
        {
            leftDown++;
        }
        else
        {
            leftDown = 0;
        }

        if (deltaHead > 0)
        {
            headUp++;
        }
        else
        {
            headUp = 0;
        }
        if (deltaRight > 0)
        {
            rightUp++;
        }
        else
        {
            rightUp = 0;
        }
        if (deltaLeft > 0)
        {
            leftUp++;
        }
        else
        {
            leftUp = 0;
        }

        if(deltaDist < 0) {
            distDecrease++;
        }
        else {
            distDecrease = 0;
        }

        if(deltaDist > 0) {
            distIncrease++;
        }
        else {
            distIncrease = 0;
        }

        oldHeadHeight = head.position.y;
        oldRightHeight = rightHand.position.y;
        oldLeftHeight = leftHand.position.y;
    }
}
