using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bodyStayInPosition : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;
    public float offset = 1.48f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //float step = speed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        Vector3 goal = new Vector3(target.position.x, target.position.y - offset, target.position.z - 0.3f);
        transform.position = goal;
    }
}
