using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SimpleJSON;



public class PressF2 : MonoBehaviour
{
    public GameObject predictCanvas;

    //�÷��̾ Ư�� �繰�� �ٰ������� FŰ�� ���� ���� ������ ���.

    bool onPlayer = false;
    public GameObject interObject;
    public GameObject popUpImage;

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        if (onPlayer == true)
        {
            popUpImage.SetActive(true);
            popUpImage.transform.forward = Camera.main.transform.forward;

            if (Input.GetKeyDown(KeyCode.F))
            {
                predictCanvas.SetActive(true);
            }
        }

        if (onPlayer == false)
        {
            popUpImage.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //���� �浹�� ���� �÷��̾���
        if (other.tag == "Player")
        {
            onPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            onPlayer = false;
        }
    }

    

    public GameObject boardCanvas;
    public void OnEscBtn()
    {
        boardCanvas.SetActive(false);
       
    }

}

