using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiPopUpBtn : MonoBehaviour
{
    public GameObject FirstUI;

    public GameObject SecondUI;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Yes()
    {
        FirstUI.SetActive(false);
        SecondUI.SetActive(true);
    }
}
