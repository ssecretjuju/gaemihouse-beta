using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneLoad : MonoBehaviour
{
    public GameObject GameUI;

    // Start is called before the first frame update
    void Start()
    {
        GameUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameUI.SetActive(true);
        }
    }
}
