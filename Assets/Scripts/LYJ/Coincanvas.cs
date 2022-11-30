using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coincanvas : MonoBehaviour
{
    public static Coincanvas Instance;
    private void Awake()
    {     
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Text coinText;

    // Start is called before the first frame update
    void Start()
    {
        coinText.text = CoinManager.Instance.coinInfo.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
