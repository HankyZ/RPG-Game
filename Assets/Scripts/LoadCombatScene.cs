using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCombatScene : MonoBehaviour
{

    public string battleScene;

    public static bool alreadyLoaded;

    private Animator animator;
    private GameObject player;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (alreadyLoaded)
            return;

        if (collision.gameObject.name != "Player")
            return;

        player = collision.gameObject;
        player.GetComponent<ExitCombatScene>().originalScene = SceneManager.GetActiveScene().name;
        player.GetComponent<ExitCombatScene>().enemy = gameObject;
        player.GetComponent<ExitCombatScene>().originalCameraPosition = Camera.main.transform.position;
        player.GetComponent<ExitCombatScene>().originalPlayerPosition = player.transform.position;
        player.GetComponent<ExitCombatScene>().originalEnemyPosition = transform.position;

        SceneManager.LoadScene(battleScene);

        animator.SetBool("InCombat", true);
        player.transform.GetComponent<Animator>().SetBool("PlayerInCombat", true);

        Camera.main.GetComponent<CameraController>().followTarget = null;
        Camera.main.transform.position = new Vector3(0, 0, -10);
        transform.position = new Vector3(1.5f, 0.5f, 0f);
        player.transform.position = new Vector3(-2f, -1f, 0f);

        alreadyLoaded = true;
    }
}
