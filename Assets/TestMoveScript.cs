using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMoveScript : MonoBehaviour {

    
    private Vector3 touchStartPos;
    private Vector3 touchEndPos;
    private Vector3 touchStartworldPos;
    private Vector3 touchEndworldPos;
    private Vector3 clickMoveDistance;
    private Vector3 objectMoveDistance;
    private Vector3 inititalPos;

    private const float MOVE_SPEED_PER_SECOND = 2.0f;

    // further feather: object slow down before stop
     
    
    // Use this for initialization
    void Start()
    {
        inititalPos = transform.position;
        Debug.Log("inititalPos is " + inititalPos);

    }

    // Update is called once per frame
    void Update()
    {
        Flick();

        /* Objective: Game object move ths same distance and direction as clickMoveDistance
         * Question1: the object will stop depends on objectMoveDistance.y, it cannot go to -y direction.
         * Question2: I do not think this is a good condition to trigger gameObject to move, It should be like:
         if(something = true){ gameObject move to the same distance as [clickMoveDistance]}
         but how can it stop?
        
        further feather: object slow down before stop
        further feather: setup gameOjbect move distance =  clickMoveDistance * 2.5
        */

        if (this.gameObject.transform.position.y <= objectMoveDistance.y)
        {
            //Object moving direction same as clicking, should be fine to remain
            this.gameObject.transform.Translate(clickMoveDistance * (MOVE_SPEED_PER_SECOND * Time.deltaTime));
            
        }

        //Question: Right Click to restart position, but it will keep going after Right Click
        Restart();

        
    }

    //Moving direction
    void Flick()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            

            touchStartPos = new Vector3(Input.mousePosition.x,
                                        Input.mousePosition.y,
                                        Input.mousePosition.z);
                        
            touchStartworldPos = Camera.main.ScreenToWorldPoint(touchStartPos);
            Debug.Log("touchStarworldPos is" + touchStartworldPos);

            
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {

            touchEndPos = new Vector3(Input.mousePosition.x,
                                      Input.mousePosition.y,
                                      Input.mousePosition.z);
                       
            touchEndworldPos = Camera.main.ScreenToWorldPoint(touchEndPos);
            Debug.Log("touchEndworldPos is" + touchEndworldPos);

            //object move distance is same as click down to click up distance
            clickMoveDistance = touchEndworldPos - touchStartworldPos;
            Debug.Log("clickMoveDistance is" + clickMoveDistance);

            objectMoveDistance = new Vector3(this.gameObject.transform.position.x + clickMoveDistance.x,
                                             this.gameObject.transform.position.y + clickMoveDistance.y,
                                             this.gameObject.transform.position.z + clickMoveDistance.z);
            Debug.Log("objectMoveDistance is" + objectMoveDistance);


            
        }
    }

    void Restart()
    {
        //Restart to inititalPos
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Debug.Log("inititalPos is " + inititalPos);
            this.gameObject.transform.position = inititalPos;

            //Question: I try to reset position and remain no moving, but it does not work
            objectMoveDistance = new Vector3(0.0f, 0.0f, 0.0f);
            this.gameObject.transform.Translate(0.0f, 0.0f, 0.0f);
        }

    }
  
}
