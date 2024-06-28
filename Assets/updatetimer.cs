using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class updatetimer : MonoBehaviour
{
    [SerializeField] 
    public TMP_Text _title;
    public MaxHealth mh;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        setTime(180-mh.getOverallRuntime());
    }

    public void setTime(float seconds){
        int minutes = (int) seconds/60;
        int s = (int) seconds%60;
        if(s/10 == 0) _title.text = minutes.ToString()+":0"+s.ToString();
        else _title.text = minutes.ToString()+":"+s.ToString();
    }
}
