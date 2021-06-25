using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownController : MonoBehaviour
{
    int countDownTime;
    [SerializeField] Text countDownTextComp;


    public void StartCountDown(int countDownStart)
    {
        countDownTime = countDownStart;
        StartCoroutine(CountDownRoutine());
    }
    
    IEnumerator CountDownRoutine()
    {
        Debug.Log("hey2");
        while (countDownTime > 0)
        {
            Debug.Log("hey1");
            countDownTextComp.text = countDownTime.ToString();
            yield return new WaitForSeconds(1f);
            countDownTime--;
        }
        countDownTextComp.enabled = false;
        GameManager.instance.StartGame();
    }
}
