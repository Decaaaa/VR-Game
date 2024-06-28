using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxHealth : MonoBehaviour
{
    private static int maxHealth = 100;
    private static int maxEnemyHealth = 100;
    private static bool toSceneSwitcher = false;

    private static float runTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        runTime+=Time.deltaTime;
        if(!toSceneSwitcher && SceneManager.getActiveScene() == 0 && runTime >= 90) {
            GameObject.Find("Object_343").GetComponent<Enemy>().EnemyHealth = 0;
        }
        else if(toSceneSwitcher && SceneManager.getActiveScene() == 0 && runTime > 174) {
            SceneManager.LoadScene(sceneBuildIndex: 0);
            setSwitch(true);
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
