using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller2 : BallController
{
    [Range(1, 100)]
    [SerializeField] float factor = 10f;

    private float startTime ;
    private Vector3 startPos  ;


    ////delsasap
    public Vector3 stPos;
    ////delsasap
    public Vector3 enPos;

    void CustomMouseDown()
    {
        Debug.Log("herllo1");
        startTime = Time.time;
        startPos = Input.mousePosition;
        startPos.z = startPos.y;
        startPos.y = 0;

        ////delsasap
        stPos = startPos;
    }

    void CustomOnMouseUp()
    {
        Debug.Log("herllo2");
        var endPos = Input.mousePosition;
        endPos.z = endPos.y;
        endPos.y = 0;

        var force = endPos - startPos;
        //force.z = force.magnitude;
        force /= (Time.time - startTime);


        //gameObject.GetComponent<Rigidbody>().AddRelativeForce(force / factor);

        gameObject.GetComponent<Rigidbody>().AddForce(force / factor);


        ////delsasap
         enPos = endPos;
        Debug.DrawRay(gameObject.transform.position, enPos - stPos, Color.red, 3f);
    }

    public override void PushTheBall()
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
