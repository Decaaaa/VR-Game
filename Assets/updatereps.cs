using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class updatereps : MonoBehaviour
{
    [SerializeField] 
    public TMP_Text _title;

    public WorkoutDetection w;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _title.text = "Num Reps: "+(w.squatCount).ToString();
    }
}
