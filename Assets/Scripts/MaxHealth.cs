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
    private static float runTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        if(SceneManager.GetActiveScene().buildIndex == 0) {
            initialTime = Time.deltaTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        runTime+=Time.deltaTime;
        if(SceneManager.GetActiveScene().buildIndex == 0 && runTime - initialTime >= 120) {
            GameObject.Find("Object_343").GetComponent<Enemy>().EnemyHealth = 0;
        }
    }

    public void updateHealth(int change)
    {
        maxHealth += change;
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
}
