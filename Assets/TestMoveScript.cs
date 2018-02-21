using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMoveScript : MonoBehaviour {

    private Vector3 StartPos;
    private Vector3 EndPos;
    private Transform myTransform;


    // Use this for initialization
    void Start () {
        this.myTransform = GetComponent<Transform>();

        StartPos = new Vector3(2, -4, 0);
        this.gameObject.transform.position = StartPos;

        EndPos = new Vector3(2, 4, 0);
    }
	
	// Update is called once per frame
	void Update () {

        
        if(myTransform.position.y >= StartPos.y && myTransform.position.y <= EndPos.y)
        {
            this.gameObject.transform.Translate(0, 0.1f, 0);

        }
        
		
	}
}
