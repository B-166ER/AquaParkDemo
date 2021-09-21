using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehavior : MonoBehaviour
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
        //force /= (Time.time - startTime);

        Debug.DrawRay(gameObject.transform.position, gameObject.transform.position + mouseRay, Color.black, 10f);
        Vector3 rotated = Quaternion.AngleAxis(90, gameObject.transform.right) * mouseRay;
        Debug.DrawRay(gameObject.transform.position, gameObject.transform.position + rotated, Color.blue, 10f);


        Vector3 targetDir = TargetReObject2.transform.position - transform.position;
        Vector3 forward = transform.forward;
        angle = Vector3.SignedAngle(targetDir, forward, Vector3.up);
        angle *= -1;
        Vector3 rotaatedforRelative = Quaternion.AngleAxis(angle , Vector3.up) * rotated;

        
        Debug.DrawRay(gameObject.transform.position, gameObject.transform.position + rotaatedforRelative, Color.yellow, 10f);
        Debug.Log("angle :"+angle);
    }




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



        Vector3 targetDir = TargetReObject2.transform.position - transform.position;
        Vector3 forward = transform.forward;
        angle = Vector3.SignedAngle(targetDir, forward, Vector3.up);

        /*
        // simulating mouse positions 
        Vector3 minPosition = new Vector3(-100f, -100f, -100f);
        Vector3 maxPosition = new Vector3(100f, 100f, 100f);
        Vector3 minPosition2 = new Vector3(-100f, 0f, 0f);
        Vector3 maxPosition2 = new Vector3(100f, 100f, 0f);

        //simulating random mouse input
        Vector3 Rstart = new Vector3(Random.Range(minPosition.x, maxPosition.x), 0, Random.Range(minPosition.z, maxPosition.z));
        Vector3 Rend = new Vector3(Random.Range(minPosition.x, maxPosition.x), 0, Random.Range(minPosition.z, maxPosition.z));
        //these are random mouse positions that works only on global positioning
        Debug.DrawRay(gameObject.transform.position, gameObject.transform.position + Rend - Rstart, Color.white, 2f);

        //simulating half so we can see which way mouse positions reflect on 3d scale
        Vector3 MousestuffStart = new Vector3(Random.Range(minPosition2.x, maxPosition2.x), Random.Range(minPosition2.y, maxPosition2.y), Random.Range(minPosition2.z, maxPosition2.z) );
        Vector3 MousestuffEnd = new Vector3(Random.Range(minPosition2.x, maxPosition2.x), Random.Range(MousestuffStart.y,  MousestuffStart.y +100 ), Random.Range(minPosition2.z, maxPosition2.z) );
        //2d to screen direction inserted onto 3d area withot any y axis info
        Debug.DrawRay(gameObject.transform.position, gameObject.transform.position + (MousestuffEnd - MousestuffStart), Color.cyan, 7f);
        Vector3 rotated = Quaternion.AngleAxis(angleaxisVal, Vector3.left) * (MousestuffEnd- MousestuffStart);
        // -90 on left axis makes mouse on on right plane x+z not y+x
        Debug.DrawRay(gameObject.transform.position, gameObject.transform.position + rotated, Color.red, 7f);

        //target position 
        Transform targetTransform = TargetRelativeObject.transform;
        //myself position these doesnt work on 0 0 0 source
        Transform selftransform = gameObject.transform;

        //////////////////////////////code snipet
        //preparation
        Vector3 vectorA = gameObject.transform.position;
        Vector3 vectorB = TargetRelativeObject.transform.position;
        float angle = Vector3.SignedAngle(gameObject.transform.position, TargetRelativeObject.transform.position - gameObject.transform.position, gameObject.transform.forward);

        float angle2 = Vector3.Angle(vectorA, vectorB);
        Vector3 cross = Vector3.Cross(vectorA, vectorB);
        if (cross.y > 0) angle2 = -angle2;
        //pick off the result
        angleBetweenBallAndTarget = angle2;
        //////////////////////////////code snipet ends

        //debug purposes only
        A = vectorA;
        B = vectorB;
        Cross = cross;

        // rotate around y axis so it can move on relative positions.
        //Vector3 rotaatedforRelative = Quaternion.AngleAxis(angleBetweenBallAndTarget+ angleBetweenBallAndTarget , Vector3.up) * rotated;
        Vector3 rotaatedforRelative = Quaternion.AngleAxis(-angleBetweenBallAndTarget - 90, Vector3.up) * rotated;

        Debug.DrawRay(gameObject.transform.position, gameObject.transform.position + rotaatedforRelative, Color.yellow, 2f);

        */

    }
    public Vector3 A;
    public Vector3 B;
    public Vector3 Cross;
}
