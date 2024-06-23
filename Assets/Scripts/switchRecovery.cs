using System.Collections;
using System.Collections.Generic;
using GLTF.Schema;
using Unity.VisualScripting;
using UnityEngine;

public class switchRecovery : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject regular;
    public GameObject recovery;
    public GameObject NinjaKrishna;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (NinjaKrishna.GetComponent<EnemyFollow>().Recovery){
            recovery.SetActive(true);
            regular.SetActive(false);
        }
        else {
            recovery.SetActive(false);
            regular.SetActive(true);
        }
    }
}
