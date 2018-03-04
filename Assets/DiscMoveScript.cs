using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscMoveScript : MonoBehaviour
{

    private Vector3 touchStartPos;
    private Vector3 touchEndPos;
    private Vector3 touchStartworldPos;
    private Vector3 touchEndworldPos;
    private Vector3 clickMoveDistance;

    
    private float movedDistance = 0.0f;//★追加 移動した距離

    private const float MOVE_SPEED_PER_SECOND = 2.0f;

    // further feather: object slow down before stop


    // Use this for initialization
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        Flick();

      
        if (movedDistance < clickMoveDistance.magnitude)
        { //★追加 移動距離がclickMoveDistanceの長さより短い場合
          //Object moving direction same as clicking, should be fine to remain
            float moveDistance = (clickMoveDistance * (MOVE_SPEED_PER_SECOND * Time.deltaTime)).magnitude;
            this.gameObject.transform.Translate(clickMoveDistance * (MOVE_SPEED_PER_SECOND * Time.deltaTime));
            movedDistance += moveDistance;
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
            //Debug.Log("touchStarworldPos is" + touchStartworldPos);


        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {

            touchEndPos = new Vector3(Input.mousePosition.x,
                                      Input.mousePosition.y,
                                      Input.mousePosition.z);

            touchEndworldPos = Camera.main.ScreenToWorldPoint(touchEndPos);
            //Debug.Log("touchEndworldPos is" + touchEndworldPos);

            //object move distance is same as click down to click up distance
            clickMoveDistance = (touchEndworldPos - touchStartworldPos);
            //Debug.Log("clickMoveDistance is" + clickMoveDistance.magnitude);

            
            movedDistance = 0.0f; //★追加 移動距離を０に初期化 

        }
    }

    void Restart()
    {
        //Restart to inititalPos
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            
            this.gameObject.transform.Translate(0.0f, 0.0f, 0.0f);
            //★追加 clickMoveDistanceの長さを０にして、移動させないようにする
            clickMoveDistance = new Vector3(0.0f, 0.0f, 0.0f);


        }

    }

}
