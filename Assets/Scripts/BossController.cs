using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private GameController gameController;
    private static bool exists;

    // Use this for initialization
    void Start()
    {
        if (!exists)
        {
            DontDestroyOnLoad(transform.gameObject);
            gameController = GameObject.Find("GameController").GetComponent<GameController>();
            exists = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name != "Player")
            return;

        gameController.DoCombat(gameObject, null);
        
    }
}
