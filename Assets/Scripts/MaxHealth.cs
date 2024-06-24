using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxHealth : MonoBehaviour
{
    private static int maxHealth = 100;
    private static bool toSceneSwitcher = false;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void updateHealth(int change)
    {
        maxHealth += change;
    }

    public int getHealth()
    {
        return maxHealth;
    }

    public void setSwitch(bool nahoryah)
    {
        toSceneSwitcher = nahoryah;
    }
    public bool getSwitch()
    {
        return toSceneSwitcher;
    }
}
