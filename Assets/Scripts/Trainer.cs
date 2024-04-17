using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trainer : MonoBehaviour
{

    public AudioSource[] audios;
    public int[] delays;
    int index;
    // GameObject CameraEnemy;
    // GameObject mc;

    // Start is called before the first frame update
    void Start()
    {
        //mc = GameObject.Find("Main Camera");
        index=0;
        audios[index].PlayDelayed(delays[index]);
        index++; 

    }

    // Update is called once per frame
    void Update()
    {
        if (index!=0){
            if (!audios[index-1].isPlaying){
                audios[index].PlayDelayed(delays[index]);
                index++;
            }
        }
        else {
            index++;
            audios[index].PlayDelayed(delays[index]);
        }
    }
}
