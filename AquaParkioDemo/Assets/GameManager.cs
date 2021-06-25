using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] CountDownController cDownController;
    [SerializeField] PlayerController mainPlayer;

    private void OnEnable()
    {
        if(instance == null)
            instance = this;
        mainPlayer.GetComponent<AirMovement>().enabled = false;
        mainPlayer.GetComponent<GroundMovement>().enabled = false;
    }

    void Start()
    {
        cDownController.StartCountDown(3);

    }

    public void StartGame()
    {
        mainPlayer.GetComponent<GroundMovement>().enabled = true;
    }

    public void PlayerReachedTarget()
    {
        Debug.Log("Finish");
    }

}
