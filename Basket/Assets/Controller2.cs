using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller2 : BallController
{

    [Range(1, 100)]
    [SerializeField] float factor = 10f;

    private float startTime;
    private Vector3 startPos;

    [SerializeField] GameObject TargetReObject2;
    [SerializeField] GameObject Vguide;

    public float angleaxisVal = -90f;
    public GameObject TargetRelativeObject;
    public float angleBetweenBallAndTarget;

    ////delsasap
    Vector3 stPos;
    ////delsasap
    Vector3 enPos;

    [SerializeField] Vector3 lastMouseMovement;
    [SerializeField] float mouseMovementTime;
    [Range(-1,1)][SerializeField] float pushtTimeMultiplier;

    void CustomMouseDown()
    {
        startTime = Time.time;
        startPos = Input.mousePosition;

        ////delsasap
        stPos = startPos;
    }
    public float angleAxisVal;
    void CustomOnMouseUp()
    {
        var endPos = Input.mousePosition;

        var force = endPos - startPos;
        Vector3 mouseRay = endPos - startPos;
        //if you wanna use time
        mouseMovementTime /= (Time.time - startTime);

        Debug.DrawRay(gameObject.transform.position, gameObject.transform.position + mouseRay, Color.black, 10f);
        Vector3 rotated = Quaternion.AngleAxis(90, gameObject.transform.right) * mouseRay;
        Debug.DrawRay(gameObject.transform.position, gameObject.transform.position + rotated, Color.blue, 10f);


        Vector3 targetDir = TargetReObject2.transform.position - transform.position;
        Vector3 forward = transform.forward;
        angle = Vector3.SignedAngle(targetDir, forward, Vector3.up);
        angle *= -1;
        Vector3 rotaatedforRelative = Quaternion.AngleAxis(angle, Vector3.up) * rotated;


        Debug.DrawRay(gameObject.transform.position, gameObject.transform.position + rotaatedforRelative, Color.yellow, 10f);

        //pointer movement is y&x 
        lastMouseMovement = endPos - startPos;
        if(lastMouseMovement.y > 0) rotaatedforRelative.y += lastMouseMovement.y * pushBallUpDependingOnMouseY;

        if (GameManager.instance.waitForTouchGroundBeforePush == false) PushTheBallImmediately(rotaatedforRelative);
        else 
        { 
            TheForceThatIsWaitingToBeAddedOneRigidBody = rotaatedforRelative;
        }


    }

    [Range(0, 3)] [SerializeField] float pushBallUpDependingOnMouseY;



    public float angle;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("custom down");
            CustomMouseDown();
        }
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("custom up");
            CustomOnMouseUp();
        }

    }

    public override void PushTheBallImmediately(Vector3 force)
    {

        if (GameManager.instance.isMouseEventTimeRelevant == true)
        {
            Vector3 tmp = Vector3.one;
            tmp *= (mouseMovementTime * pushtTimeMultiplier);
            force = tmp;
            Debug.Log("force :" + force);
            gameObject.GetComponent<Rigidbody>().AddForce(force);
        }
        else
        {
            gameObject.GetComponent<Rigidbody>().AddForce(force);
        }

    }




}
