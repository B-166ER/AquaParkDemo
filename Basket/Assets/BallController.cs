using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BallController : MonoBehaviour
{
    public Vector3 TheForceThatIsWaitingToBeAddedOneRigidBody;
    public abstract void PushTheBallImmediately(Vector3 force);
    public virtual void WaitTouchGroundAndPush()
    {
        if (GameManager.instance.waitForTouchGroundBeforePush == true)
        {
            Debug.Log("added force :" + TheForceThatIsWaitingToBeAddedOneRigidBody);
            gameObject.GetComponent<Rigidbody>().AddForce(TheForceThatIsWaitingToBeAddedOneRigidBody);
        }
        else return;
    }
}
