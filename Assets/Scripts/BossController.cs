using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private static bool exists;

    // Use this for initialization
    void Start()
    {
        if (!exists)
        {
            DontDestroyOnLoad(transform.gameObject);
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
}
