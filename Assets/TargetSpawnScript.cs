using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawnScript : MonoBehaviour {

    private Vector3 targetSpawnPos;

	// Use this for initialization
    //How to get 3diji random number?
	void Start () {
        targetSpawnPos = new Vector3(Random.Range(-1.0000f, 1.0000f), Random.Range(0.8000f, 2.3000f), 0.0f);
        this.gameObject.transform.position = targetSpawnPos;
        Debug.Log("First Generated targetSpawnPos is " + targetSpawnPos);
    }
	
	// Update is called once per frame
	void Update () {
        Respawn();
        
    }

    void Respawn()
    {
        if (Input.GetMouseButtonDown(1))
        {
            targetSpawnPos = new Vector3(Random.Range(-1.0000f, 1.0000f), Random.Range(0.8000f, 2.3000f), 0.0f);
            Debug.Log("Respawn Generated targetSpawnPos is " + targetSpawnPos);

            this.gameObject.transform.position = targetSpawnPos;
        }
    }
}