using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    private CombatController combatController;

    private bool allowCombat;

    // Use this for initialization
    void Start()
    {
        allowCombat = true;
        combatController = GameObject.Find("CombatController").GetComponent<CombatController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DoCombat(GameObject enemy, string combatScene)
    {
        if (!allowCombat)
            return;

        combatController.allowCombat = true;
        combatController.StartCombat(enemy, combatScene);
    }

}
