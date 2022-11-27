using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;


public class Test : MonoBehaviour
{

    class Item
    {
        public int status;
        public string message;
        public List<Room> data;
    }

    class Room
    {
        public int roomCode;
        public string roomTitle;
        public int roomLimitedNumber;
        public int roomRegistedNumber;
        public double roomYield;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello, world!");

        string jsonData = "{" +
                          "\"status\": 200," +
                          "\"message\": \"successful\"," +
                          "\"data\": [" +
                          "{" +
                          "\"roomCode\": 9999," +
                          "\"roomTitle\": \"test\"," +
                          "\"roomLimitedNumber\": 15," +
                          "\"roomRegistedNumber\": 1," +
                          "\"roomYield\": 0" +
                          "}," +
                          "{" +
                          "\"roomCode\": 9998," +
                          "\"roomTitle\": \"집에가고싶어요\"," +
                          "\"roomLimitedNumber\": 13," +
                          "\"roomRegistedNumber\": 1," +
                          "\"roomYield\": 0" +
                          "}" +
                          "]" +
                          "}";

        JObject jObject = JObject.Parse(jsonData);

        Debug.Log(jObject);

        List<Room> roomList = JsonConvert.DeserializeObject<Item>(jsonData).data;


        foreach (Room room in roomList)
        {
            Debug.Log(room.roomTitle + ", " + room.roomLimitedNumber + ", " + room.roomRegistedNumber + ", " + room.roomYield);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
