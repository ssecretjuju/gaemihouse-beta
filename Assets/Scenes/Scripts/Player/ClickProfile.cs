using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// 다른 캐릭터를 클릭하면 해당 캐릭터의 정보가 뜨게 하고싶다.

//public class ClickProfile : MonoBehaviour
//{

//    public GameObject canvas;
//    private GraphicRaycaster m_Raycaster;
//    private PointerEventData m_PointerEventData;
//    private EventSystem m_EventSystem;

//    // Start is called before the first frame update
//    void Start()
//    {
//        m_Raycaster = canvas.GetComponent<GraphicRaycaster>();
//        m_EventSystem = GetComponent<EventSystem>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        clickText();
//    }

//    void clickText()
//    {
//        if (Input.GetMouseButtonDown(0))
//        {
//            m_PointerEventData = new PointerEventData(m_EventSystem);
//            m_PointerEventData.position = Input.mousePosition;

//            List<RaycastResult> results = new List<RaycastResult>();

//            m_Raycaster.Raycast(m_PointerEventData, results);

//            GameObject hitText = results[0].gameObject;
//            print(hitText);
//        }
//    }


