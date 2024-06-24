using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bodyStayInPositionAgain : MonoBehaviour
{
    public GameObject parentalUnit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(parentalUnit.transform.position.x, transform.position.y, parentalUnit.transform.position.z-0.3f);
    }
}
