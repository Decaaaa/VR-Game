using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trainer : MonoBehaviour
{

    public AudioSource[] audios;
    public int[] delays;
    int index;
    GameObject mc;

    bool playerInRightPos(){
        Vector3 playerPos = mc.transform.position;
        return ((playerPos.x>314.34 && playerPos.x<324.62) && (playerPos.z>-207 && playerPos.z<-202.77));
    }

    // Start is called before the first frame update
    void Start()
    {
        mc = GameObject.Find("Main Camera");
        index=0;
        if (playerInRightPos()) {
            audios[index].PlayDelayed(delays[index]);
            index++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (index!=0){
            if (playerInRightPos() && !audios[index-1].isPlaying){
                audios[index].PlayDelayed(delays[index]);
                index++;
            }
        }
        else {
            if (playerInRightPos()){
                index++;
                audios[index].PlayDelayed(delays[index]);
            }
        }
    }
}
