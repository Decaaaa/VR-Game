using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class hapticsa : MonoBehaviour
{
    [SerializeField]
    XRBaseController right;

    [SerializeField]
    XRBaseController left;


    public GameObject rightHand;
    public GameObject leftHand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SendHapticsR(float intensity){
        if (right!=null){
            float newIntensity = intensity/12;
            if(newIntensity > 1) newIntensity = 1;
            right.SendHapticImpulse(newIntensity, 0.25f);
        }
    }
    public void SendHapticsL(float intensity){
        if (left!=null){
            float newIntensity = intensity/12;
            if(newIntensity > 1) newIntensity = 1;
            left.SendHapticImpulse(newIntensity, 0.25f);
        }
    }
}
