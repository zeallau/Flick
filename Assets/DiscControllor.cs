using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscControllor : MonoBehaviour
{

    private Vector3 touchStartPos;
    private Vector3 touchEndPos;
    private float distanceY;
    private float distanceX;
    private Vector3 moveDir = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 inititalPos;
    private const float MOVE_SPEED_PER_SECOND = 2.0f;
    private Vector3 discDes = new Vector3(0.0f, 0.0f, 0.0f);

    // Use this for initialization
    void Start()
    {
        inititalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Flick();
        //this.gameObject.transform.Translate(moveDir * (MOVE_SPEED_PER_SECOND * Time.deltaTime));

        if( this.gameObject.transform.position.y <= distanceY && this.gameObject.transform.position.x <= distanceX)
        {
            this.gameObject.transform.Translate(discDes * (MOVE_SPEED_PER_SECOND * Time.deltaTime));
        }
        
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
            moveDir = Vector3.zero;
            transform.position = inititalPos;
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
        //Vector3 dir = new Vector3(directionX, directionY, 0.0f).normalized;

        // Move to the same direction as directionX, directionY
        //this.gameObject.transform.Translate(dir);

        DiscDestination();
    }

    void DiscDestination()
    {
        float distanceX = (touchEndPos.x - touchStartPos.x) * 0.01f;
        float distanceY = (touchEndPos.y - touchStartPos.y) * 0.01f;

        //ベクトルの長さを１にする
        //moveDir = (touchEndPos - touchStartPos).normalized;


        discDes = new Vector3(distanceX, distanceY, 0.0f);
    }
}