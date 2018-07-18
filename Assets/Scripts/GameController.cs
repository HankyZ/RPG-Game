using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    private CombatController combatController;

    private static bool exists;

    public static bool levelCompleted;

    private bool allowCombat;

    // Use this for initialization
    void Start()
    {
        if (exists)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(transform.gameObject);
            exists = true;
            allowCombat = true;
            combatController = GameObject.Find("CombatController").GetComponent<CombatController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (levelCompleted)
            allowCombat = false;
    }

    public void DoCombat(GameObject enemy, string combatScene)
    {
        if (!allowCombat)
            return;

        combatController.allowCombat = true;
        combatController.StartCombat(enemy, combatScene);
    }

}
