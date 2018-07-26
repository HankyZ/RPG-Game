using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject followTarget;
    public float moveSpeed = 0.1f;

    private Camera myCam;
    private Vector3 targetPosition;
    private static bool cameraExists;

	// Use this for initialization
	void Start () {
        myCam = GetComponent<Camera>();
        if (!cameraExists)
        {
            DontDestroyOnLoad(gameObject);
            cameraExists = true;
        }
        else
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
        myCam.orthographicSize = (Screen.height / 100f) / 2f;

        if (followTarget)
        {
            targetPosition = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
	}
}
