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
            scene++;
            SceneManager.LoadScene("KrishnaWorld");
        }
    }
}
