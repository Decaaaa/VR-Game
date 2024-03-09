using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    public Image FillImage;
    float CurrentHealth;
    GameObject CameraEnemy;
    // Start is called before the first frame update
    void Start()
    {
        CameraEnemy=GameObject.Find("Cool Robot Again");
    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealth = CameraEnemy.GetComponent<Enemy>().EnemyHealth;
        FillImage.fillAmount = CurrentHealth/100;
    }
}
