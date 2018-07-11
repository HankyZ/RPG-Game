using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitCombatScene : MonoBehaviour
{

    public string originalScene;

    public GameObject enemy;

    public Vector3 originalPlayerPosition;
    public Vector3 originalEnemyPosition;

    public bool exitCombat;
    Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!exitCombat)
        {
            return;
        }

        if (exitCombat)
        {
            SceneManager.LoadScene(originalScene);

            transform.position = originalPlayerPosition;

            if (enemy != null)
            {
                enemy.transform.position = originalEnemyPosition;
            }

            animator.SetBool("PlayerInCombat", false);
            enemy.GetComponent<Animator>().SetBool("InCombat", false);
            
            exitCombat = false;
        }
    }
}
