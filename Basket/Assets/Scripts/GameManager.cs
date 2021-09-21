using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Singleton
    public static GameManager instance;

    // canvas to be activated after shot
    [SerializeField] Canvas EndingCanvas;

    // the event that will be fired after the shot
    public event Action onShotOccured;

    [SerializeField] public bool isMouseEventTimeRelevant;
    [SerializeField] public bool waitForTouchGroundBeforePush;
    public void ShotOccured()
    {
        if(onShotOccured != null)
        {
            onShotOccured();
            // wait and show restart button
            StartCoroutine( WaitAndEnd() );
        }
    }

    private IEnumerator WaitAndEnd()
    {
        yield return new WaitForSecondsRealtime(5f);
        EndingCanvas.enabled = true;
    }

    public void SceneReload()
    {
        SceneManager.LoadScene(0);
    }

    private void OnEnable()
    {
        instance = this;
    }
}
