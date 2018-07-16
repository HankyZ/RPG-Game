﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatController : MonoBehaviour
{

    public string defaultCombatScene;

    public string combatScene;
    public bool allowCombat;
    public bool combatOver;

    private bool exists;
    private bool inCombat;

    private GameObject player;
    private GameObject enemy;

    private string originalScene;
    private Vector3 originalCameraPosition;
    private Vector3 originalPlayerPosition;
    private Vector3 originalEnemyPosition;


    // Use this for initialization
    void Start()
    {
        if (exists)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(transform.gameObject);
        player = GameObject.Find("Player");
        exists = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (combatOver)
        {
            ExitCombatScene();
        }

    }

    public void StartCombat(GameObject enemy, string combatScene)
    {
        if (!allowCombat)
            return;

        if (combatScene == null || combatScene.Length == 0)
            this.combatScene = defaultCombatScene;

        else
            this.combatScene = combatScene;

        this.enemy = enemy;

        LoadCombatScene();

    }

    private void LoadCombatScene()
    {
        originalScene = SceneManager.GetActiveScene().name;
        originalCameraPosition = Camera.main.transform.position;
        originalPlayerPosition = player.transform.position;
        originalEnemyPosition = enemy.transform.position;

        SceneManager.LoadScene(combatScene);

        player.GetComponent<Animator>().SetBool("PlayerInCombat", true);
        enemy.GetComponent<Animator>().SetBool("InCombat", true);

        Camera.main.GetComponent<CameraController>().followTarget = null;

        Camera.main.transform.position = new Vector3(0, 0, -10);
        enemy.transform.position = new Vector3(1.5f, 0.5f, 0f);
        player.transform.position = new Vector3(-2f, -1f, 0f);
    }

    private void ExitCombatScene()
    {
        SceneManager.LoadScene(originalScene);

        Camera.main.GetComponent<CameraController>().followTarget = gameObject;

        Camera.main.transform.position = originalCameraPosition;
        transform.position = originalPlayerPosition;

        if (originalEnemyPosition.Equals(new Vector3(1000, 1000, 1000)))
        {
            enemy.transform.position = originalEnemyPosition;
        }

        player.GetComponent<Animator>().SetBool("PlayerInCombat", false);
        enemy.GetComponent<Animator>().SetBool("InCombat", false);

        inCombat = false;
        combatOver = false;
    }
}