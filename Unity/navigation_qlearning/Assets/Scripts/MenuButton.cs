using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{   // 필요없는 스크립트

    Button SocketBnt;
    Button ScanBnt;
    Button GetPathBnt;
    Button DrawLineBnt;
    Button MainBnt;
    public bool isOnclick = false;
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        MainBnt = GameObject.Find("Connect_Button").GetComponent<Button>();
        MainBnt.onClick.AddListener(TaskOnClick);

        SocketBnt = GameObject.Find("SocketButton").GetComponent<Button>();
        SocketBnt.gameObject.SetActive(false);

        ScanBnt = GameObject.Find("ScanButton").GetComponent<Button>();
        ScanBnt.gameObject.SetActive(false);

        GetPathBnt = GameObject.Find("PathButton").GetComponent<Button>();
        GetPathBnt.gameObject.SetActive(false);

        DrawLineBnt = GameObject.Find("DrawButton").GetComponent<Button>();
        DrawLineBnt.gameObject.SetActive(false);

        


}

    // Update is called once per frame
    void Update()
    {
        if (isOnclick == true)
        {
            isOnclick = false;
            count++;
            
        }
        if (count % 2 == 0)
        {
            SocketBnt.gameObject.SetActive(false);
            ScanBnt.gameObject.SetActive(false);
            GetPathBnt.gameObject.SetActive(false);
            DrawLineBnt.gameObject.SetActive(false);
        }
        else
        {
            SocketBnt.gameObject.SetActive(true);
            ScanBnt.gameObject.SetActive(true);
            GetPathBnt.gameObject.SetActive(true);
            DrawLineBnt.gameObject.SetActive(true);
        }
    }
    private void TaskOnClick()
    {
        isOnclick = true;
    }
}
