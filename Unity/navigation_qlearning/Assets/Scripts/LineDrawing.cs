using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class LineDrawing : MonoBehaviour
{
    // 서버에서 받은 결과로 길을 그리는 스크립트

    private LineRenderer lineRenderer;
    public Transform[] points;

    public GameObject m_firstPersonCamera; //posetracking
    public GameObject cameraTarget;   //SpherePointer

    public BLE BL;

    //public Android_QLearning_Result QR;

    float elapsed = 0.0f;
    float dist = 0.0f;
    public Transform Player;

    public string[] array;
    int count = 0;
    int btncount = 0;

    Button btn;
    private bool isOnclick = false;

    static byte[] receiveBytes = new byte[1024];
    public Text result;
    public Text result1;
    string message;

    ArrayList myArray = new ArrayList();

    public float init_x, init_y, init_z;

    void Start()
    {   
        lineRenderer = GetComponent<LineRenderer>();

        btn = GameObject.Find("DrawButton").GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

    }

    void Update()
    {   
        if (isOnclick == true)
        {
            message = BL.path;
            array = message.Split(',');
            result.text = array[0];
            
            isOnclick = false;
            btncount++;
            DrawLine();

        }
        if (btncount > 5)
        {
            DrawLine();
            result.text = Vector3.Distance(Player.transform.position, points[84].transform.position).ToString();
        }

    }

    private void TaskOnClick()
    {
        isOnclick = true;
    }
    void DrawLine()
    {
        //count는 꼭 맞춰야한다.
        count = message.Split(',').Length;
        lineRenderer.positionCount = count;

        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            lineRenderer.SetPosition(i, points[Convert.ToInt32(array[i])].position);
            
            if (Vector3.Distance(Player.transform.position, points[Convert.ToInt32(array[i])].transform.position) < 2)
            {
                if (i == 0)
                    continue;

                else
                    points[Convert.ToInt32(array[i - 1])].transform.position = points[Convert.ToInt32(array[i])].transform.position;
            }
        }
        init_x = points[Convert.ToInt32(array[0])].position.x;
        init_y = points[Convert.ToInt32(array[0])].position.y;
        init_z = points[Convert.ToInt32(array[0])].position.z;
    }



    /*
    static void receiveStr(IAsyncResult ar)
    {
        Socket transferSock = (Socket)ar.AsyncState;
        int strLength = transferSock.EndReceive(ar);
        Console.WriteLine(Encoding.Default.GetString(receiveBytes));
    }

    */
}




/*
private void LateUpdate()
{
//dist = Vector3.Distance(Player.transform.position, points[0].transform.position);
        
   // print(" distance : " + dist);
}*/
/* 지나간 길 지우기.
        if (Vector3.Distance(Player.transform.position, points[0].transform.position) > 10)
        {
            array[0] = 1;
            for (int i = 0; i < 4; i++)
            {
                lineRenderer.SetPosition(i, points[array[i]].position);
            }
        }
       if(Vector3.Distance(Player.transform.position, points[0].transform.position) > 20)
        {
            array[0] = 2;
            array[1] = 2;
            for (int i = 0; i < 4; i++)
            {
                lineRenderer.SetPosition(i, points[array[i]].position);
            }
           
        }
        if (Vector3.Distance(Player.transform.position, points[0].transform.position) > 30)
        {
            array[0] = 3;
            array[1] = 3;
            array[2] = 3;
            for (int i = 0; i < 4; i++)
            {
                lineRenderer.SetPosition(i, points[array[i]].position);
            }
        }

      */
/*
 *     void getQLearningResult()
    {
        for (int i = 0; i < QR.path.Length; i++)
        {   
           
            array[i] = QR.path[i];
            count++;
        }
    }
 * 
 * 
 */