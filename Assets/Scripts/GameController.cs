using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject enemy;
    private int scene = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy.GetComponent<Enemy>().EnemyHealth <= 0 && scene == 0) {
            if (GameObject.Find("MaxHealth Backup").GetComponent<MaxHealth>().getSwitch())
            {
                SceneManager.LoadScene(sceneBuildIndex: 2);
                GameObject.Find("MaxHealth Backup").GetComponent<MaxHealth>().setSwitch(false);
            }
            else
            {
                SceneManager.LoadScene(sceneBuildIndex: 1);
                GameObject.Find("MaxHealth Backup").GetComponent<MaxHealth>().setSwitch(true);
            }
        }
    }
}
