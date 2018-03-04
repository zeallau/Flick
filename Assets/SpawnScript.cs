using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {

    private Vector3 discSpawnPos;

	// Use this for initialization
	void Start () {
        discSpawnPos = new Vector3(Random.Range(-3.0000f, 3.0000f), -4.5f, 0.0f);
        this.gameObject.transform.position = discSpawnPos;

    }
	
	// Update is called once per frame
	void Update () {
        Respawn();


    }

    void Respawn()
    {
        if (Input.GetMouseButtonDown(1))
        {

            discSpawnPos = new Vector3(Random.Range(-3.0000f, 3.0000f), -4.5f, 0.0f);
            this.gameObject.transform.position = discSpawnPos;
        }
    }
}
