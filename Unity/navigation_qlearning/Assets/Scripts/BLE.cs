using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BLE : MonoBehaviour
{
    // 비콘 신호 수신 및 서버로 송신, 서버에서 강화학습 결과를 받음

    private AndroidJavaObject AndroidObject = null;

    Button btn;
    bool isOnclick = false;

    Button btn1;
    bool isOnclick1 = false;

    Button btn2;
    bool isOnclick2 = false;

    public string path;
    public Text result;

    private AndroidJavaObject GetJavaObject()
    {
        if (AndroidObject == null)
        {
            AndroidObject = new AndroidJavaObject("com.example.plugin1.ble");
        }
        return AndroidObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        AndroidJavaClass jclass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject activity = jclass.GetStatic<AndroidJavaObject>("currentActivity");
        GetJavaObject().Call("setActivity", activity);

        //GetJavaObject().Call("BluetoothScan");
        btn = GameObject.Find("SocketButton").GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        btn1 = GameObject.Find("ScanButton").GetComponent<Button>();
        btn1.onClick.AddListener(TaskOnClick1);

        btn2 = GameObject.Find("PathButton").GetComponent<Button>();
        btn2.onClick.AddListener(TaskOnClick2);

    }

    // Update is called once per frame
    void Update()
    {

        if (isOnclick == true)
        {
            //isOnclick = false;
            GetJavaObject().Call("ClientSocketOpen", "165.246.240.6", "50005");
            //GetJavaObject().Call("BluetoothScan");
            isOnclick = false;
        }

        if (isOnclick1 == true)
        {
            //isOnclick = false
            //path = GetJavaObject().Call<string>("getPath");

            GetJavaObject().Call("BluetoothScan");
            isOnclick1 = false;
        }

        if (isOnclick2 == true)
        {
            //isOnclick = false
            //path = GetJavaObject().Call<string>("getPath");
            path = GetJavaObject().Call<string>("getPath");
            result.text = path;
            isOnclick2 = false;
        }




    }
    public void TaskOnClick()
    {

        isOnclick = true;

    }

    public void TaskOnClick1()
    {

        isOnclick1 = true;

    }
    public void TaskOnClick2()
    {

        isOnclick2 = true;

    }

}