using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class updatemaxforcetext : MonoBehaviour
{

    [SerializeField] 
    public TMP_Text _title;
    
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _title.text="Max Force: "+((int)enemy.GetComponent<Enemy>().maxHitStrength).ToString();
    }
}
