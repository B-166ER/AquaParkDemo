using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirMovement : MonoBehaviour
{
    [SerializeField] GameObject playerBody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LocalStartFlying()
    {
        gameObject.GetComponentInChildren<Rigidbody>().AddForce(0, 200, 0);
        rollAngle = 0;
    }
    public float AirSpeed;
    float rollAngle;
    public float RollMaxAngle;
    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponentInChildren<Rigidbody>().AddForce (playerBody.transform.TransformDirection (playerBody.transform.forward) );
        Vector3 newVelocity = playerBody.transform.forward * AirSpeed;
        newVelocity.y = gameObject.GetComponentInChildren<Rigidbody>().velocity.y;

        gameObject.GetComponentInChildren<Rigidbody>().velocity = newVelocity;
        rollAngle += Input.GetAxis("Horizontal") * Time.deltaTime;
        rollAngle = Mathf.Clamp(rollAngle, -RollMaxAngle, RollMaxAngle);
        playerBody.transform.Rotate(new Vector3(0, rollAngle , 0));
    }
}
