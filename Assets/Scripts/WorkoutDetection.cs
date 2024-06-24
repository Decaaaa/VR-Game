using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkoutDetection : MonoBehaviour
{
    private bool squats = false;
    private bool jacks = false;

    public int points = 0;
    public Transform head;
    public Transform leftHand;
    public Transform rightHand;
    public int numPoints = 10;

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
    private int squatCount = 0;

    private bool startedJJ = false;
    private bool finishedJJ = false;
    private bool prevJJ = false;
    private int JJCount = 0;

    private float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        oldHeadHeight = head.position.y;
        oldRightHeight = rightHand.position.y;
        oldLeftHeight = leftHand.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        UpdateVariables();
        TrackSquats();
        TrackJJ();

        if(finishedSquat && !prevSquat)
        {
            squatCount++;
        }

        if (finishedJJ && !prevJJ)
        {
            JJCount++;
        }

        prevSquat = finishedSquat;
        prevJJ = finishedJJ;

        points = (squatCount + JJCount) * numPoints;
        Debug.Log(points);
    }

    void TrackSquats()
    {
        if (headDown > 30 && headDown > headUp)
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
        if ((leftDown > 30 && leftDown > leftUp) && (leftDown > 30 && leftDown > leftUp))
        {
            startedJJ = true;
            finishedJJ = false;
        }

        if (startedJJ)
        {
            if (leftUp > 30 && rightUp > 30)
            {
                startedJJ = false;
                finishedJJ = true;
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

        oldHeadHeight = head.position.y;
        oldRightHeight = rightHand.position.y;
        oldLeftHeight = leftHand.position.y;
    }
}
