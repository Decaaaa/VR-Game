using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public Image FillImage;
    float CurrentHealth;
    GameObject CameraPlayer;
    public GameObject maxHealthObj;
    // Start is called before the first frame update
    void Start()
    {
        CameraPlayer=GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealth = CameraPlayer.GetComponent<Player>().playerHealth;
        FillImage.fillAmount = CurrentHealth/(maxHealthObj.GetComponent<MaxHealth>().getHealth());
    }
}
