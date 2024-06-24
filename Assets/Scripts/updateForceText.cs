using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem.Controls;

public class updateForceText : MonoBehaviour
{
    [SerializeField] 
    public TMP_Text _title;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateText(float velocity){
        _title.text = "Punch Force: " + ((int) velocity).ToString(); 
    }
}
