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

    void Flick()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("ClickDown");
            
            touchStartPos = new Vector3(Input.mousePosition.x,
                                        Input.mousePosition.y,
                                        Input.mousePosition.z);
                                        
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Debug.Log("ClickUp");
            
            touchEndPos = new Vector3(Input.mousePosition.x,
                                      Input.mousePosition.y,
                                      Input.mousePosition.z);
            GetDirection();
            
        }
    }

    void GetDirection()
    {
        Debug.Log("hello");
        
        float directionX = touchEndPos.x - touchStartPos.x;
        float directionY = touchEndPos.y - touchStartPos.y;
        string Direction;

        if (Mathf.Abs(directionY) < Mathf.Abs(directionX))
        {
            if (30 < directionX)
            {
                //右向きにフリック
                Direction = "right";

                Debug.Log("Right");
            }
            else if (-30 > directionX)
            {
                //左向きにフリック
                Direction = "left";
            }
        }

        else if (Mathf.Abs(directionX) < Mathf.Abs(directionY)){
            if (30 < directionY)
            {
                //上向きにフリック
                Direction = "up";
            }
            else if (-30 > directionY)
            {
                //下向きのフリック
                Direction = "down";
            }
        }
        else
        {
            //タッチを検出
            Direction = "touch";
        }
        

    }

    

}
