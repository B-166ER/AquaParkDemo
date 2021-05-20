using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class GroundMovement : MonoBehaviour
{
    PlayerController playerController;

    [SerializeField] float playerGroundSpeed;

    [SerializeField] PathCreator sidePath;
    [SerializeField] GameObject playerBody;
    public float SidepathPosition;
    public int SideMovementSpeed;

    [SerializeField] PathCreator gamePath;
    float gamePathPosition;
    // Start is called before the first frame update
    void Start()
    {
        SidepathPosition = sidePath.path.length / 2;
        playerController = gameObject.GetComponent<PlayerController>();
    }
    private void OnEnable()
    {
        Vector3 currentBodyPoisiton = playerBody.transform.position;
        gamePathPosition = gamePath.path.GetClosestDistanceAlongPath(currentBodyPoisiton);
        transform.position = gamePath.path.GetPointAtDistance(gamePathPosition);
        transform.rotation = gamePath.path.GetRotationAtDistance(gamePathPosition);
        SidepathPosition = sidePath.path.GetClosestDistanceAlongPath(currentBodyPoisiton);
        playerBody.transform.position = sidePath.path.GetPointAtDistance(SidepathPosition);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (SidepathPosition < 0.1f || SidepathPosition > sidePath.path.length - 0.1f)
            playerController.StartFlying();

        if (horizontal != 0 )
        {
            SidepathPosition += horizontal * SideMovementSpeed * Time.deltaTime;
            SidepathPosition = Mathf.Clamp(SidepathPosition, 0, sidePath.path.length - 0.1f);
            playerBody.transform.position = sidePath.path.GetPointAtDistance(SidepathPosition);
        }

        gamePathPosition += playerGroundSpeed * Time.deltaTime * playerController.globalSpeedModifier;
        transform.position = gamePath.path.GetPointAtDistance(gamePathPosition);
        transform.rotation = gamePath.path.GetRotationAtDistance(gamePathPosition);

        playerBody.transform.position = sidePath.path.GetPointAtDistance(SidepathPosition);
    }
}
