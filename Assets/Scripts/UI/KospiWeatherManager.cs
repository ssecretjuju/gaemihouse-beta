using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 가져온 코스피 지수 값이 0이면 맵에 비가 내린다
// 가져온 코스피 지수 값이 1이면 비가 내리지 않는다
// 임의로 1로 바뀌는 버튼 넣기!!!!
public class KospiWeatherManager : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(KospiInfoManager.Instance.kospiInfo == 0)
        {
            //비가내림
        }
        else
        {

        }
    }

    //값 바꾸는 버튼
    public void changeKospi()
    {
        KospiInfoManager.Instance.kospiInfo = 1;
    }
}
