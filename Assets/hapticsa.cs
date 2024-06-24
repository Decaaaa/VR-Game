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

    public bool  isHapticL;
    public bool  isHapticR;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isHapticR){
            SendHapticsR();
        }
        if (isHapticL){
            SendHapticsL();
        }
    }

    void SendHapticsR(){
        if (right!=null){
            right.SendHapticImpulse(0.4f, 0.1f);
        }
    }
    void SendHapticsL(){
        if (left!=null){
            left.SendHapticImpulse(0.4f, 0.1f);
        }
    }
}
