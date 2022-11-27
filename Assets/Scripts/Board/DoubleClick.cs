using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleClick : MonoBehaviour
{
    private float firstClickTime, timeBetweenClicks;
    private bool coroutineAllowed;
    private int clickCounter;
    public GameObject playerInfoWindow;


    // Start is called before the first frame update
    void Start()
    {
        firstClickTime = 0f;
        timeBetweenClicks = 0.2f;
        clickCounter = 0;
        coroutineAllowed = true;

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void DoubleClick12()
    {
        if (Input.GetMouseButtonUp(0))
            clickCounter += 1;

        if (clickCounter == 1 && coroutineAllowed)
        {
            firstClickTime = Time.time;
            StartCoroutine(DoubleClickDetection());
        }
    }
    private IEnumerator DoubleClickDetection()
    {
        coroutineAllowed = false;
        while (Time.time < firstClickTime + timeBetweenClicks)
        {
            if (clickCounter == 2)
            {
                //팝업창 활성화
                playerInfoWindow.SetActive(true);
                Debug.Log("Double Click");
                break;
            }
            yield return new WaitForEndOfFrame();
        }

        clickCounter = 0;
        firstClickTime = 0f;
        coroutineAllowed = true;
    }
}

