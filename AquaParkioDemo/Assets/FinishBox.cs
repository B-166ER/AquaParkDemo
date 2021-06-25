using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishBox : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.PlayerReachedTarget();
    }
}
