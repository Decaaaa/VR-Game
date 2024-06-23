using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class n : MonoBehaviour
{
    public GameObject heyy;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, heyy.transform.position.y, transform.position.z);
    }
}
