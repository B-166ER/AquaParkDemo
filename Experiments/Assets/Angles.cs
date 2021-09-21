using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angles : MonoBehaviour
{
    public GameObject Target;
    public float angle;
    // Start is called before the first frame update

    public Vector3 origin;
    public Vector3 target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        origin = gameObject.transform.position;
        target = Target.transform.position;
        angle = Vector3.SignedAngle(gameObject.transform.position, target-gameObject.transform.position,gameObject.transform.forward);


        //preparation
        Vector3 vectorA = gameObject.transform.position;
        Vector3 vectorB = Target.transform.position;

        float angle2 = Vector3.Angle(vectorA, vectorB);
        Vector3 cross = Vector3.Cross(vectorA, vectorB);
        if (cross.x < 0) angle2 = -angle2;
        Debug.Log(vectorA +"\n"+vectorB+"\n"+ cross);
        //pick off the result
        angle = angle2;


        //angle = Vector2.Angle(new Vector2(origin.x, origin.z), new Vector2(target.x, target.z));
        //angle = SignedAngleBetween(origin, target,gameObject.transform.forward);
    }
    float SignedAngleBetween(Vector3 a, Vector3 b, Vector3 n)
    {
        // angle in [0,180]
        float angle = Vector3.Angle(a, b);
        float sign = Mathf.Sign(Vector3.Dot(n, Vector3.Cross(a, b)));

        // angle in [-179,180]
        float signed_angle = angle * sign;

        // angle in [0,360] (not used but included here for completeness)
        //float angle360 =  (signed_angle + 180) % 360;

        return signed_angle;
    }

}
