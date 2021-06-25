using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketBehaviour : MonoBehaviour
{
    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.onShotOccured += onShot;
        rend = gameObject.GetComponent<Renderer>();
    }
    private void onShot()
    {
        StartCoroutine( onShotRoutine() );
    }
    private IEnumerator onShotRoutine()
    {
        // animation to flash yellow color after shot
        float duration = 0.9f;
        Renderer renderer = gameObject.GetComponent<Renderer>();
        Color originalColor = renderer.material.color;
        Color animColor = Color.yellow;


        while (duration > 0)
        {
            duration -= Time.deltaTime;

            //float lerp = Mathf.PingPong(Time.time, duration) / duration;
            
            
            rend.material.color = Color.Lerp(animColor ,originalColor  , duration);


            //.material.color = animColor;

            yield return new WaitForEndOfFrame();
        }
        rend.material.color = originalColor;
    }

}
