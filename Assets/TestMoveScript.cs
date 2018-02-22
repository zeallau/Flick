using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMoveScript : MonoBehaviour {

    public Transform target;
    private Vector3 touchStartPos;
    private Vector3 touchEndPos;
    private float directionX;
    private float directionY;
    private Vector3 moveDir = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 inititalPos;
    private const float MOVE_SPEED_PER_SECOND = 8.0f;
    private Vector3 discDes = new Vector3(0.0f, 0.0f, 0.0f);
    Camera cam;
    //Vector3 viewPortPos = gameObject.main.WorldToViewPortPoint(TestDisc);

    // Use this for initialization
    void Start()
    {
        inititalPos = transform.position;
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Flick();

        if(this.gameObject.transform.position.y <= directionY /15 || this.gameObject.transform.position.x >= directionX / 30)
        {
            this.gameObject.transform.Translate(moveDir * (MOVE_SPEED_PER_SECOND * Time.deltaTime));
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
        Debug.Log("inititalPos is" + inititalPos);
        Vector3 screenPos = cam.WorldToScreenPoint(target.position);

        Debug.Log("target is " + screenPos.x + " pixels from the left");
        
        directionX = touchEndPos.x - inititalPos.x;
        directionY = touchEndPos.y - inititalPos.y;

        //.normalized用來限制移動半徑為1
        //Vector3 dir = new Vector3(directionX, directionY, 0.0f).normalized;

        // Move to the same direction as directionX, directionY
        //this.gameObject.transform.Translate(dir);

        //ベクトルの長さを１にする
        moveDir = (touchEndPos - touchStartPos).normalized ;

    }


}
