using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

    private GameController gameController;

    public GameObject enemy;
    public string combatScene;
    public float spawnChance;
    static bool disabled;

	// Use this for initialization
	void Start () {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (disabled)
            return;

        if (collision.gameObject.name != "Player")
            return;

        if (Random.Range(0, 49) == 0)
        {
            gameController.DoCombat(gameObject, combatScene);
        }

        
    }
}
