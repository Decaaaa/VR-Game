using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerFollow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = InputTracking.GetLocalPosition(XRNode.CenterEye);
        transform.rotation = InputTracking.GetLocalRotation(XRNode.CenterEye);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
