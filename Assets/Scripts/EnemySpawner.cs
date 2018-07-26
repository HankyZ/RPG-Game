using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    private GameController gameController;

    private GameObject player;
    private GameObject enemy;
    public string combatScene;
    private bool alreadyActivated;

    // Use this for initialization
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        player = GameObject.Find("Player");
        enemy = GameObject.Find("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerPosition = player.transform.position;

        // if player is outside of the zone, reset activated
        if (playerPosition.x < transform.position.x - 0.5 || playerPosition.x >= transform.position.x + 0.5 ||
            playerPosition.y < transform.position.y - 0.5 || playerPosition.y >= transform.position.y + 0.5)
        {
            alreadyActivated = false;
            return;
        }

        // otherwise, spawn enemy if not activated already
        if (!alreadyActivated)
        {
            if (Random.Range(0, 10) == 0)
            {
                gameController.DoCombat(enemy, combatScene);
            }
            alreadyActivated = true;

        }

    }
    
}
