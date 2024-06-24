using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float playerHealth;
    public GameObject maxHealthObj;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = maxHealthObj.GetComponent<MaxHealth>().getHealth();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(playerHealth);   
    }
}
