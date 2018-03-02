using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour {

    private Vector3 targetPos;
    private Vector3 velocity;

    private GameObject disc;
    private float targetRadius;
    private float discToCenter;
    private float scoreYellow;
    private float scoreRed;
    private float scoreBlue;

    bool scoreUp = false;

    // Use this for initialization
    void Start () {
        targetPos = this.gameObject.transform.position;
        disc = GameObject.Find("TestDisc");
        velocity = disc.GetComponent<Rigidbody2D>().velocity;

    }
	
	// Update is called once per frame
	void Update () {
        velocity = disc.GetComponent<Rigidbody2D>().velocity;

        Debug.Log("velocity" + disc.GetComponent<Rigidbody2D>().velocity);
        //Debug.Log("velocity" + velocity);

        if (scoreUp == true)
        {
            //Debug.Log("discToCenter is" + discToCenter);
            //Debug.Log("targetRadius is" + targetRadius);
            //Debug.Log("scoreYellow" + scoreYellow);
            //Debug.Log("scoreRed" + scoreRed);
            //Debug.Log("scoreBlue" + scoreBlue);
            //scoreUp = false;
        }

        if (discToCenter < scoreYellow && scoreUp == true)
        {
            Debug.Log("+ 100 Score");
            scoreUp = false;
        }

    }

    
    private void OnTriggerStay2D(Collider2D collider)
    {
        //targetPos is 0
        discToCenter = Vector3.Distance(disc.transform.position, targetPos);
        
        //get distance between circle center and disc
        //score distance
        Debug.Log("discToCenter is" + discToCenter);


    }
    

    private void OnTriggerEnter2D(Collider2D collider)
    {
        targetRadius = Vector3.Distance(collider.transform.position, targetPos);

        //get distance between collider and circle center
        //targetRadius = 2
        //Debug.Log("targetRadius is" + targetRadius);

        scoreYellow = targetRadius * 0.166f;
        //Debug.Log("scoreYellow" + scoreYellow);

        scoreRed = targetRadius * 0.463f;
        //Debug.Log("scoreRed" + scoreRed);

        scoreBlue = targetRadius * 0.761f;
        //Debug.Log("scoreBlue" + scoreBlue);

        scoreUp = true;
    }



    
    
}
