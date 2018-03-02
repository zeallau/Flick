using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewDisc : MonoBehaviour {

    Vector3 touchStartPos;
    Vector3 worldPos;

    // Use this for initialization
    void Start () {
        //cam = GetComponent<Camera>();

        Vector3 screenPos = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);
        //Debug.Log("target is " + screenPos.x + " pixels from the left");

        
    }
	
	// Update is called once per frame
	void Update () {
        ShowPos();

    }

    void ShowPos()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            touchStartPos = new Vector3(Input.mousePosition.x,
                                        Input.mousePosition.y,
                                        Input.mousePosition.z);

            //Debug.Log("touchStarPos is" + touchStartPos);

            worldPos = Camera.main.ScreenToWorldPoint(touchStartPos);
            //Debug.Log("worldPos is" + worldPos);


            //transform.position = inititalPos;
        }

    }
}
