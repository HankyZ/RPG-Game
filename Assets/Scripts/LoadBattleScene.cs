using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadBattleScene : MonoBehaviour {

    public string battleScene;
    private Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name != "Hero")
        {
            return;
        }

        SceneManager.LoadScene(battleScene);
        animator.SetBool("BossInBattle", true);
        collision.transform.GetComponent<Animator>().SetBool("HeroInBattle", true);

    }
}
