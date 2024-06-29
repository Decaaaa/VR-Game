using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
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
                GameObject.Find("MaxHealth Backup").GetComponent<MaxHealth>().playWin();
                GameObject.Find("MaxHealth Backup").GetComponent<MaxHealth>().setEnemyHealth(GameObject.Find("MaxHealth Backup").GetComponent<MaxHealth>().getEnemyHealth()+125);
                GameObject.Find("MaxHealth Backup").GetComponent<MaxHealth>().setSwitch(false);
                SceneManager.LoadScene(sceneBuildIndex: 2);
            }
            else
            {
                GameObject.Find("MaxHealth Backup").GetComponent<MaxHealth>().playWin();
                GameObject.Find("MaxHealth Backup").GetComponent<MaxHealth>().setSwitch(true);
                SceneManager.LoadScene(sceneBuildIndex: 1);
            }
        }
        else if(player.GetComponent<Player>().playerHealth <= 0 && scene == 0) {
            if (GameObject.Find("MaxHealth Backup").GetComponent<MaxHealth>().getSwitch())
            {
                GameObject.Find("MaxHealth Backup").GetComponent<MaxHealth>().playLose();
                GameObject.Find("MaxHealth Backup").GetComponent<MaxHealth>().setEnemyHealth(GameObject.Find("MaxHealth Backup").GetComponent<MaxHealth>().getEnemyHealth()+125);
                GameObject.Find("MaxHealth Backup").GetComponent<MaxHealth>().setSwitch(false);
                SceneManager.LoadScene(sceneBuildIndex: 2);
            }
            else
            {
                GameObject.Find("MaxHealth Backup").GetComponent<MaxHealth>().playLose();
                GameObject.Find("MaxHealth Backup").GetComponent<MaxHealth>().setSwitch(true);
                SceneManager.LoadScene(sceneBuildIndex: 1);
            }
        }
    }
}
