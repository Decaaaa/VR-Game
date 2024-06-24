using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bodyStayInPositionAgain : MonoBehaviour
{
    public GameObject parentalUnit;
    public float speed;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        Vector3 target = new Vector3(parentalUnit.transform.position.x, transform.position.y, parentalUnit.transform.position.z-0.3f);
        transform.position = Vector3.MoveTowards(transform.position, target, step);
    }
}
