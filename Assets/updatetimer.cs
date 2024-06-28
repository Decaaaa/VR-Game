using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class updatetimer : MonoBehaviour
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
        //setTime(239);
    }

    public void setTime(int seconds){
        int minutes = seconds/60;
        int s = seconds%60;
        _title.text = minutes.ToString()+":"+s.ToString();
    }
}
