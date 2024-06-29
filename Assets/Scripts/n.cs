using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class n : MonoBehaviour
{
    public GameObject heyy;
    public GameObject parent;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(parent.transform.position.x, heyy.transform.position.y, parent.transform.position.z);
    }
}
