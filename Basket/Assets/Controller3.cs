using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller3 : BallController
{
    public GameObject front;
    public GameObject basket;


    private float startTime;
    private Vector3 startPos;
    ////delsasap
    public Vector3 stPos;
    ////delsasap
    public Vector3 enPos;

    void CustomMouseDown()
    {
        startTime = Time.time;
        startPos = Input.mousePosition;
        //Debug.Log("değişmeden " + startPos);
        //startPos.z = startPos.y;
        //startPos.y = 0;
        Debug.Log("değişti " + startPos);

        ////delsasap
        stPos = startPos;
    }
    [Range(0, 4500)]
    [SerializeField] float ballMoveFactor = 6;


    [Range(5, 2500)]
    [SerializeField] float mouseFactor = 1000f;
    void CustomOnMouseUp()
    {
        Debug.Log("CustomOnMouseUp");
        var mouseUpPos = Input.mousePosition;
        var mouseVector = mouseUpPos - startPos;



        var ballToHoopVector = basket.transform.position - gameObject.transform.position;
        var ballToHoopAngle = Vector3.Angle(basket.transform.position, gameObject.transform.position);


        //force.z = force.magnitude;
        //force /= (Time.time - mouseDownTime);


        //gameObject.GetComponent<Rigidbody>().AddRelativeForce(force / factor);

        var mouseVectorWithoutVertical = new Vector3(mouseVector.x, 0, mouseVector.z); // z zaten zero
        var mouseVectorVerticalLength = Mathf.Abs(mouseVector.y);


        Vector3 rotatedVector = ballToHoopVector;

        if (ballToHoopAngle > 30)
        {
            rotatedVector = Quaternion.AngleAxis(30, Vector3.left) * ballToHoopVector;
        }

        gameObject.GetComponent<Rigidbody>().AddForce(rotatedVector.normalized * ballMoveFactor * mouseVectorVerticalLength);
        gameObject.GetComponent<Rigidbody>().AddForce(mouseVectorWithoutVertical.normalized * mouseFactor);

        Debug.Log("ballToHoopAngle: " + ballToHoopAngle);
        Debug.Log("mouseVector: " + mouseVector);
        Debug.Log("mouseVectorWithoutVertical: " + mouseVectorWithoutVertical);
        Debug.Log("ballToHoopVector.normalized: " + ballToHoopVector.normalized);

        //gameObject.GetComponent<Rigidbody>().AddForce((((basket.transform.position - gameObject.transform.position).normalized * (force.magnitude * factor)) + force) * factor);

        //        ((basket.transform.position - gameObject.transform.position).normalized * force.magnitude);

        ////delsasap
        //enPos = endPos;
        //Debug.DrawRay(gameObject.transform.position, enPos - stPos, Color.red, 3f);
    }


    [Range(0, 1000)]
    [SerializeField] float factor = 0.01f;
    void CustomOnMouseUp1()
    {
        Debug.Log("herllo2");
        var endPos = Input.mousePosition;
        //Debug.Log("değişmeden " + endPos);
        endPos.z = endPos.y;
        endPos.y = 0;

        var force = endPos - startPos;
        //force.z = force.magnitude;
        //force /= (Time.time - startTime);


        //gameObject.GetComponent<Rigidbody>().AddRelativeForce(force / factor);

        var angleFromBallToHoop = basket.transform.position - gameObject.transform.position;


        var res = (angleFromBallToHoop.normalized * factor) * force.z;
        var asd = force;
        Debug.Log("asd1" + asd);
        asd.y = 0;
        asd.z = 0;
        Debug.Log("asd2" + asd);

        var angle = Mathf.Atan2(angleFromBallToHoop.z, angleFromBallToHoop.x) * Mathf.Rad2Deg;
        var forceAngle = (Mathf.Atan2(force.z, force.x) * Mathf.Rad2Deg) - 45;

        Debug.Log((Mathf.Atan2(force.z, force.x) * Mathf.Rad2Deg) - 90 + " <---");
        Debug.Log((Mathf.Atan2(force.z, force.x) * Mathf.Rad2Deg)  + " <111");
        Debug.Log(Mathf.Atan2(angleFromBallToHoop.z, angleFromBallToHoop.x) * Mathf.Rad2Deg + " <222");
        //Math.atan2(-p.y, -p.x) * 180 / Math.PI;

        var vector = Quaternion.AngleAxis(-forceAngle, Vector3.right) * angleFromBallToHoop;



        gameObject.GetComponent<Rigidbody>().AddForce(vector*factor);


        ////delsasap
        enPos = endPos;
        Debug.DrawRay(gameObject.transform.position, enPos - stPos, Color.red, 3f);
    }
    void CustomOnMouseUp2()
    {
        var endPos = Input.mousePosition;
        //Debug.Log("değişmeden " + endPos);
        //endPos.z = endPos.y;
       //endPos.y = 0;
        //Debug.Log("değişti " + endPos);

        var force = endPos - startPos;
        //force.z = force.magnitude;
        force /= (Time.time - startTime);


        //gameObject.GetComponent<Rigidbody>().AddRelativeForce(force / factor);

        

        gameObject.GetComponent<Rigidbody>().AddForce( ( ((basket.transform.position - gameObject.transform.position).normalized * (force.magnitude*factor) ) + force )* factor);

//        ((basket.transform.position - gameObject.transform.position).normalized * force.magnitude);

        ////delsasap
        enPos = endPos;
        Debug.DrawRay(gameObject.transform.position, enPos - stPos, Color.red, 3f);
    }

    public override void PushTheBall()
    {

        

       // gameObject.GetComponent<Rigidbody>().AddForce( (basket.transform.position - gameObject.transform.position).normalized * 500 );
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            CustomMouseDown();
        }
        if (Input.GetMouseButtonUp(0))
        {
            CustomOnMouseUp();
        }
    }
}
