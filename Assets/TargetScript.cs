using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour {

    private Vector3 targetPos;
    private float lastDTC;
    private float currentDTC;
    private float finalDTC;
    

    private GameObject disc;
    private float targetRadius;
    private float discToCenter;
    private float scoreYellow;
    private float scoreRed;
    private float scoreBlue;

    bool scoreUp = false;
    bool logUp = false;
    bool next = false;

    private Vector3 targetSpawnPos;

    // Use this for initialization
    void Start () {
        targetPos = this.gameObject.transform.position;
        disc = GameObject.Find("Disc");

        targetSpawnPos = new Vector3(Random.Range(-1.0000f, 1.0000f), Random.Range(0.8000f, 2.3000f), 0.0f);
        this.gameObject.transform.position = targetSpawnPos;
        Debug.Log("First Generated targetSpawnPos is " + targetSpawnPos);

        
    }

    // Update is called once per frame
    void Update () {
        Respawn();
    }

    // want to get the stopped value of discToCenter
    private void OnTriggerStay2D(Collider2D collider)
    {
        //Distance between Disc and center point of target
        discToCenter = Vector3.Distance(disc.transform.position, targetPos);

        /*how to use Translate to get "Stop"
        if (disc.transform.Translate.x == 0 && disc.transform.Translate.y == 0)
        {
        }
        */

        
        //To compare currentDTC and lastDTC
        currentDTC = discToCenter;
        
        if (currentDTC == lastDTC && logUp == true)  
        {
            finalDTC = discToCenter;
            Debug.Log("finalDTC subposed is" + finalDTC);
                        
            logUp = false;
            next = true;
        }

        lastDTC = currentDTC;

        //The finalDTC here same as above because of (next == true)            
        if (next == true)
        {
            if (finalDTC <= scoreYellow && scoreUp == true)
            {
                Debug.Log("finalDTC in scoring is " + finalDTC + " and scoreYellow Distance is " + scoreYellow);
                Debug.Log("finalDTC in scoring between 0 and scoreYellow " + scoreYellow + ". Get + 100 Score.");
                scoreUp = false;

            }
            else if (finalDTC > scoreYellow && finalDTC <= scoreRed && scoreUp == true)
            {
                Debug.Log("finalDTC in scoring  is" + finalDTC + "and scoreRed Distance is " + scoreRed);
                Debug.Log("finalDTC in scoring between scoreYellow " + scoreYellow + " and scoreRed " + scoreRed + ". Get + 50 Score.");
                scoreUp = false;

            }
            else if (finalDTC > scoreRed && finalDTC <= scoreBlue && scoreUp == true)
            {
                Debug.Log("finalDTC in scoring  is" + finalDTC + "and scoreBlue Distance is " + scoreBlue);
                Debug.Log("finalDTC in scoring between scoreRed " + scoreRed + " and scoreBlue " + scoreBlue + ". Get + 20 Score.");
                scoreUp = false;
            }
            else if (finalDTC > scoreBlue && finalDTC <= targetRadius && scoreUp == true)
            {
                Debug.Log("finalDTC in scoring  is" + finalDTC + "and targetRadius Distance is " + targetRadius);
                Debug.Log("finalDTC in scoring between scoreBlue " + scoreBlue + " and Radius " + targetRadius + ". Get + 0 Score. Missing");
                scoreUp = false;
            }
        }

        if (next)
        {
            next = false;
        }
    }
    

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Distance from target center to Radius
        targetRadius = Vector3.Distance(collider.transform.position, targetPos);
        
        scoreYellow = targetRadius * 0.2f;
        //Debug.Log("scoreYellow" + scoreYellow);

        scoreRed = targetRadius * 0.5f;
        //Debug.Log("scoreRed" + scoreRed);

        scoreBlue = targetRadius * 0.8f;
        //Debug.Log("scoreBlue" + scoreBlue);

        scoreUp = true;
        logUp = true;
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
