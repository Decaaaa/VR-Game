using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MaxHealth : MonoBehaviour
{
    private static int maxHealth = 100;
    private static int maxEnemyHealth = 100;
    private static bool toSceneSwitcher = false;

    private static float initialTime = 0;
    private static float prevInitialTime = 0;
    private static float runTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        //if(SceneManager.SceneManager.GetActiveScene().buildIndex == 0) {
        //    initialTime = TIme.deltaTIme;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        runTime+=Time.deltaTime;
        if(runTime - initialTime < getOverallRuntime()) {
            if(SceneManager.GetActiveScene().buildIndex == 0 && getOverallRuntime() >= 180) GameObject.Find("Object_343").GetComponent<Enemy>().EnemyHealth = 0;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 0 && getOverallRuntime() >= 120) GameObject.Find("Object_343").GetComponent<Enemy>().EnemyHealth = 0;
        
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
        initialTime = runTime;
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
