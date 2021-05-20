using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using System;

public class PlayerController : MonoBehaviour
{
    AirMovement airMovementComponent;
    GroundMovement groundMovementComponent;

    [SerializeField] PathCreator gamePath;
    float gamePathPosition;
    public int MovementSpeed;

    [SerializeField] PathCreator sidePath;
    [SerializeField] GameObject playerBody;
    public float SidepathPosition;
    [SerializeField] float sidePositionMin;
    [SerializeField] float sidePositionMax;
    public int SideMovementSpeed;

    [SerializeField] bool isMovingOnRoad;
    [SerializeField] bool isFlying;
    // Start is called before the first frame update
    void Start()
    {
        SidepathPosition = sidePath.path.length / 2;
        airMovementComponent = gameObject.GetComponent<AirMovement>();
        groundMovementComponent = gameObject.GetComponent<GroundMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection( Vector3.down ), Color.red );
        CheckGrounded();
        if( (SidepathPosition<0.1f || SidepathPosition> sidePath.path.length - 0.1f) && isMovingOnRoad )
            StartFlying();
        if (grounded && isFlying)
            StartLanding();

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        /*
        if (vertical != 0 && isMovingOnRoad)
        {
            gamePathPosition -= vertical  * MovementSpeed * Time.deltaTime;
            transform.position = gamePath.path.GetPointAtDistance(gamePathPosition);
            transform.rotation = gamePath.path.GetRotationAtDistance(gamePathPosition);
        }
        if (horizontal != 0 && isMovingOnRoad)
        {
            SidepathPosition += horizontal * SideMovementSpeed * Time.deltaTime;
            SidepathPosition = Mathf.Clamp(SidepathPosition, 0, sidePath.path.length - 0.1f);
            playerBody.transform.position = sidePath.path.GetPointAtDistance(SidepathPosition);
        }
        */

        if (horizontal != 0 && isFlying)
        {
            //SidepathPosition += horizontal * SideMovementSpeed * Time.deltaTime;
            //SidepathPosition = Mathf.Clamp(SidepathPosition, 0, sidePath.path.length - 0.1f);
            //playerBody.transform.position = sidePath.path.GetPointAtDistance(SidepathPosition);
        }
        if (isFlying)
        {
            //GetComponentInChildren<Rigidbody>().MovePosition( playerBody.transform.position + ( playerBody.transform.forward * Time.deltaTime ) );
            
            /*
            Vector3 newVelocity =  playerBody.transform.forward;
            newVelocity.y = 0;

            gameObject.GetComponentInChildren<Rigidbody>().velocity = newVelocity;
            playerBody.transform.Rotate(new Vector3(0,Input.GetAxis("Horizontal"),0)  );
            */
        }
        if (isMovingOnRoad)
        {
            playerBody.transform.localRotation = Quaternion.Euler (Vector3.zero) ;
        }
    }
    [SerializeField] float flyForwardMagnitude;
    public void StartLanding()
    {
        airMovementComponent.enabled = false;
        groundMovementComponent.enabled = true;

        Debug.Log("Landed");
        isFlying = false;
        isMovingOnRoad = true;
        gameObject.GetComponentInChildren<Rigidbody>().isKinematic = false;

        /*
        Vector3 currentBodyPoisiton = playerBody.transform.position;
        gamePathPosition = gamePath.path.GetClosestDistanceAlongPath(currentBodyPoisiton);
        transform.position = gamePath.path.GetPointAtDistance(gamePathPosition);
        transform.rotation = gamePath.path.GetRotationAtDistance(gamePathPosition);
        SidepathPosition = sidePath.path.GetClosestDistanceAlongPath(currentBodyPoisiton);
        playerBody.transform.position = sidePath.path.GetPointAtDistance(SidepathPosition) ;
        */

    }

    public void StartFlying()
    {
        airMovementComponent.enabled = true;
        groundMovementComponent.enabled = false;

        Debug.Log("Started Flying");
        isFlying = true;
        isMovingOnRoad = false;
        gameObject.GetComponentInChildren<Rigidbody>().isKinematic = false;
        airMovementComponent.LocalStartFlying();
    }

    bool isJumping;
    public void Jump()
    {
        isJumping = true;
        StartCoroutine(JumpRoutine());
    }

    IEnumerator JumpRoutine()
    {
        isJumping = true;
        grounded = false;
        StartFlying();
        yield return new WaitForEndOfFrame();
        //gameObject.GetComponentInChildren<Rigidbody>().AddForce(new Vector3(0f, 5f, 0f));
        yield return new WaitForSeconds(1f);
        isJumping = false;
    }

    public float globalSpeedModifier;
    public void Brake()
    {
        StartCoroutine(BreakRoutine());
    }

    IEnumerator BreakRoutine()
    {
        globalSpeedModifier = 0f;
        while (globalSpeedModifier < 1)
        {
            globalSpeedModifier += 0.1f;
            yield return new WaitForSecondsRealtime(0.1f);
        }
    }

    [SerializeField] LayerMask layerMask;
    [SerializeField] float groundDistance;
    [SerializeField] bool grounded;
    private void CheckGrounded()
    {
        if (isJumping) { 
            grounded = false;
            return;
        }
        Debug.DrawRay(playerBody.transform.position, Vector3.down, Color.blue);

        Ray downRay = new Ray(playerBody.transform.position, Vector3.down);
        RaycastHit hit;
        if(Physics.Raycast(playerBody.transform.position, transform.TransformDirection(Vector3.down), out hit, groundDistance, layerMask))
        {
            Debug.DrawRay(playerBody.transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }
}
