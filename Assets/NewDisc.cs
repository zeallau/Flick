using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewDisc : MonoBehaviour {

    //public Transform NewDisc;
    Camera cam;


    // Use this for initialization
    void Start () {
        cam = GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update () {
        
        Vector3 screenPos = cam.WorldToScreenPoint(this.gameObject.transform.position);
        Debug.Log("target is " + screenPos.x + " pixels from the left");
    }
}
