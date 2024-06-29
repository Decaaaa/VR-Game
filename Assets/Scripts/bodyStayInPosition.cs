using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bodyStayInPosition : MonoBehaviour
{
    public Transform target;
    float speed = 5f;
    float offset = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //float step = speed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        Vector3 goal = new Vector3(target.position.x, target.position.y /*- offset*/, target.position.z /*+ 0.08f*/);
        //Debug.Log("before: " + transform.rotation);
        //Debug.Log("camera: " + target.rotation);
        transform.position = target.position;
        transform.Rotate(0.0f, target.rotation.y-transform.rotation.y, 0.0f, Space.Self);
        //Debug.Log("after: " + transform.rotation);
    }
}
