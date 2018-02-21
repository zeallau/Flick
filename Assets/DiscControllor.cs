using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscControllor : MonoBehaviour {

    private Vector3 touchStartPos;
    private Vector3 touchEndPos;
    

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        Flick();
	}

    //Moving direction
    void Flick()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
                       
            touchStartPos = new Vector3(Input.mousePosition.x,
                                        Input.mousePosition.y,
                                        Input.mousePosition.z);

            Debug.Log(touchStartPos);
                                        
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
                      
            touchEndPos = new Vector3(Input.mousePosition.x,
                                      Input.mousePosition.y,
                                      Input.mousePosition.z);

            Debug.Log(touchEndPos);

            GetDirection();
            
        }
    }

    void GetDirection()
    {
        float directionX = touchEndPos.x - touchStartPos.x;
        float directionY = touchEndPos.y - touchStartPos.y;

        //.normalized用來限制移動半徑為1
        Vector3 dir = new Vector3(directionX, directionY, 0.0f).normalized;
                
        // Move to the same direction as directionX, directionY
        this.gameObject.transform.Translate(dir);

        GoDistance();
    }

    void GoDistance()
    {
        float distanceX = (touchEndPos.x - touchStartPos.x) * 10;
        float distanceY = (touchEndPos.y - touchStartPos.y) * 10;


    }
}
