 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

 public class BTN : MonoBehaviour
{
    public Text score;
    public Text averageScore;

    private float reactTime;
    private float checkTime0;
    float checkTime1;

    private float totalTime;
    private float averageTime;
    public GameObject end;
    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        end.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void click()
    {
        transform.localPosition = new Vector2(Random.Range(-270, 270), Random.Range(-130, 130));
        if (count > 0)
        {
            checkTime1 = checkTime0;
            checkTime0 = Time.time;
            reactTime = (checkTime0 - checkTime1) * 1000;
            totalTime = totalTime + reactTime;

            score.text = reactTime.ToString("F0");
        }
        else
        {
            checkTime0 = Time.time;
        }

        if (count == 5)
        {
            averageTime = totalTime / 5;

            Time.timeScale = 0;

            end.SetActive(true);
            averageScore.text = averageTime.ToString("F0");
            count = 0;
            totalTime = 0;

            transform.localPosition = new Vector2(0, 0);
        }
        else
        {
            count++;
        }
    }

    public void OKBtn()
    {
        SceneManager.LoadScene("[Beta]LYJ_LobbyScene");
    }
}
