using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    private Button attackButton;

    private CombatController combatController;
    private GameObject player;

    // Use this for initialization
    void Start() {
        attackButton = GameObject.Find("AttackButton").GetComponent<Button>();
        player = GameObject.Find("Player");

        combatController = GameObject.Find("CombatController").GetComponent<CombatController>();


        attackButton.onClick.AddListener(() =>
        {
            StartCoroutine(waiter());
        });

    }

    IEnumerator waiter()
    {
        player.GetComponent<Animator>().SetTrigger("PlayerAttack");
        yield return new WaitForSeconds(2);
        combatController.combatOver = true;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
