using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public GameObject GameUI;

    // Start is called before the first frame update
    void Start()
    {
        GameUI.SetActive(false);
    }

    public void ClickStart()
    {
        GameUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
