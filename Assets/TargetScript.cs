using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour {

    private Vector3 targetPos;
    private GameObject disc;

    // Use this for initialization
    void Start () {
        targetPos = this.gameObject.transform.position;


	}
	
	// Update is called once per frame
	void Update () {
        RightClick();

        disc = GameObject.Find("TestDisc");

    }


    private void OnTriggerStay2D(Collider2D collider)
    {
        Debug.Log("target hit");
        Debug.Log("targetPos.Distance is" + Vector3.Distance(disc.transform.position, targetPos));
    }

  


    
    private void RightClick()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Debug.Log("targetPos is" + targetPos) ;
            
        }
    }
    
}
