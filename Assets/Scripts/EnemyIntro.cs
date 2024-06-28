using System.Collections;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyIntro : MonoBehaviour
{
    public Animator animator;        // Reference to the Animator component
    public float shakeMagnitude = 0.2f; // Magnitude of the shake
    public GameObject enemyPrefab;   // Reference to the enemy GameObject prefab
    public GameObject nk;
    public Transform spawnPoint;     // Transform where the enemy will be instantiated
    public Camera mainCamera;        // Reference to the main Camera

    public bool end = false;
    public float duration = 1f;

    private void Start()
    {
        // Start the 
        enemyPrefab.GetComponent<SkinnedMeshRenderer>().enabled=false;   
        enemyPrefab.GetComponent<Enemy>().enabled=false;
        nk.GetComponent<EnemyFollow>().enabled = false;
        StartCoroutine(PlayAnimation());
    }


    private IEnumerator PlayAnimation()
    {
        // Play the animation
        animator.SetTrigger("PlayAnimation");

        // Wait for the end of the frame to ensure the animation state has been updated
        yield return new WaitForEndOfFrame();

        // Get the animation clip length
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        if (clipInfo.Length == 0)
        {
            yield break;
        }

        float animationDuration = clipInfo[0].clip.length;


        // Wait for the animation duration minus 2 seconds
        yield return new WaitForSeconds(animationDuration - 2f);

        enemyPrefab.GetComponent<SkinnedMeshRenderer>().enabled=true;   
        enemyPrefab.GetComponent<Enemy>().enabled=true;
        nk.GetComponent<EnemyFollow>().enabled = true;

        // Instantiate the enemy GameObject
        //Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

        // Wait for the remaining 2 seconds of the animation
        yield return new WaitForSeconds(2f);
        end = true;
    }
}
