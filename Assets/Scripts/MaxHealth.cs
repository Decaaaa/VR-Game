using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MaxHealth : MonoBehaviour
{
    private static int maxHealth = 100;
    private static int maxEnemyHealth = 100;
    private static bool toSceneSwitcher = false;

    public AudioSource win;
    public AudioSource lose;

    private static int prevTime;
    private static int runTime;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //playWin();
        if ((int)Time.time>prevTime){
            prevTime = (int)Time.time;
            runTime++;
        }
        if(toSceneSwitcher && SceneManager.GetActiveScene().buildIndex == 0 && runTime >= 180) GameObject.Find("Object_343").GetComponent<Enemy>().EnemyHealth = 0;
        else if(!toSceneSwitcher && SceneManager.GetActiveScene().buildIndex == 0 && runTime >= 120) GameObject.Find("Object_343").GetComponent<Enemy>().EnemyHealth = 0;
    }

    public void updateHealth(int change)
    {
        maxHealth += change;
    }

    public int getRuntime(){
        return runTime;
    }

    public int getHealth()
    {
        return maxHealth;
    }
    public void setEnemyHealth(int health)
    {
        maxEnemyHealth = health;
    }
    public int getEnemyHealth() 
    {
        return maxEnemyHealth;
    }
    public void setSwitch(bool nahoryah)
    {
        toSceneSwitcher = nahoryah;
    }
    public bool getSwitch()
    {
        return toSceneSwitcher;
    }
    public void printTime() {
        Debug.Log(runTime);
    }
    
    public void playWin(){
        win.Play();
    }
    public void playLose(){
        lose.Play();
    }
}
