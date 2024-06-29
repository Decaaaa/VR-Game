using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MaxHealth : MonoBehaviour
{
    private static int maxHealth = 100;
    private static int maxEnemyHealth = 100;
    private static bool toSceneSwitcher = false;

    private static float initialTime;
    private static float prevInitialTime;
    private static float runTime;
    //private static float prevRunTime;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        //if(SceneManager.SceneManager.GetActiveScene().buildIndex == 0) {
        //    initialTime = TIme.deltaTIme;
        //}
        initialTime = Time.realtimeSinceStartup;
        prevInitialTime = Time.realtimeSinceStartup;
        //prevRunTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        runTime += Time.realtimeSinceStartup-runTime;
        if(runTime - initialTime < getOverallRuntime()) {
            if(SceneManager.GetActiveScene().buildIndex == 0 && getOverallRuntime() >= 180) GameObject.Find("Object_343").GetComponent<Enemy>().EnemyHealth = 0;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 0 && getOverallRuntime() >= 10) GameObject.Find("Object_343").GetComponent<Enemy>().EnemyHealth = 0;
        //printTime();
    }

    public void updateHealth(int change)
    {
        maxHealth += change;
    }

    public float getRuntime(){
        return runTime;
    }
    public float getOverallRuntime(){
        return runTime-prevInitialTime;
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
        if(nahoryah) prevInitialTime = initialTime;
        initialTime = Time.realtimeSinceStartup;
    }
    public bool getSwitch()
    {
        return toSceneSwitcher;
    }
    public void setInitialTime(float time)
    {
        initialTime = time;
    }
    public void setPrevInitialTime(float time)
    {
        prevInitialTime = time;
    }
    public void printTime() {
        Debug.Log(runTime);
    }
}
