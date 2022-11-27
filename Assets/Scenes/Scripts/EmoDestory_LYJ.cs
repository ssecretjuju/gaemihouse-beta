using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmoDestory_LYJ : MonoBehaviour
{

    public float emoTime = 1f;
    public float checkTime = 0;
    public bool emoOn = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(emoOn == true)
        {
            checkTime += Time.deltaTime;
            if(checkTime > emoTime)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = null;
                emoOn = false;
                checkTime = 0;
            }
        }
        
    }
}
