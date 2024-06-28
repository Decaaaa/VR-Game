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
        // if(maxHealthObj.GetComponent<MaxHealth>().getSwitch()) maxHealthObj.GetComponent<MaxHealth>().setPrevInitialTime(maxHealthObj.GetComponent<MaxHealth>().getRuntime());
        // else maxHealthObj.GetComponent<MaxHealth>().setInitialTime(maxHealthObj.GetComponent<MaxHealth>().getRuntime());
        playerHealth = maxHealthObj.GetComponent<MaxHealth>().getHealth();
        //Debug.Log("marijuana");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(playerHealth);   
    }
}
