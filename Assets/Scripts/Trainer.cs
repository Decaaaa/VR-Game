using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trainer : MonoBehaviour
{

    public AudioSource[] audios;
    public int[] delays;
    public Animator anim;
    public int[] animState;
    int index;
    // GameObject CameraEnemy;
    // GameObject mc;

    // Start is called before the first frame update
    void Start()
    {
        //mc = GameObject.Find("Main Camera");
        index=0;
        audios[index].PlayDelayed(delays[index]);
        anim.SetInteger("newInt", animState[index]);
        index++; 

    }

    // Update is called once per frame
    void Update()
    {
        if (index!=0){
            if (!audios[index-1].isPlaying){
                audios[index].PlayDelayed(delays[index]);
                anim.SetInteger("newInt", animState[index]);
                index++;
            }
        }
        else {
            index++;
            audios[index].PlayDelayed(delays[index]);
            anim.SetInteger("newInt", animState[index]);
        }

        if(index == audios.Length)
        {
            if (GameObject.Find("maxHealth").GetComponent<MaxHealth>().getSwitch())
            {
                SceneManager.LoadScene(sceneBuildIndex: 2);
                GameObject.Find("maxHealth").GetComponent<MaxHealth>().setEnemyHealth(GameObject.Find("maxHealth").GetComponent<MaxHealth>().getEnemyHealth()+125);
                GameObject.Find("maxHealth").GetComponent<MaxHealth>().setSwitch(false);
            }
            else
            {
                SceneManager.LoadScene(sceneBuildIndex: 0);
                GameObject.Find("maxHealth").GetComponent<MaxHealth>().setSwitch(true);
            }
        }
    }
}
