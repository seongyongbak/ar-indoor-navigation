using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Android_QLearning_Result : MonoBehaviour
{
    // 필요없는 스크립트


}
/*
    public int[] path = new int[1024];
    public Text result;

    //  TcpClient clientSocket = new TcpClient(); // 소켓
    // NetworkStream stream = default(NetworkStream);
    //string message = string.Empty;
    static byte[] receiveBytes = new byte[1024];

    static void receiveStr(IAsyncResult ar)
    {
        Socket transferSock = (Socket)ar.AsyncState;
        int strLength = transferSock.EndReceive(ar);
        Console.WriteLine(Encoding.Default.GetString(receiveBytes));
    }

    // Start is called before the first frame update
    void Start()
    {
        
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //여기에 port와 아이피 
        socket.Connect("165.246.45.31", 50005);

        if (socket.Connected)
            Console.WriteLine("Get QLearing Result...");

        socket.BeginReceive(receiveBytes, 0, 1024, SocketFlags.None,
                      new AsyncCallback(receiveStr), socket);

        
    }
    void Update()
    {

        //setpath();
        // GetMessage();
        result.text = Encoding.Default.GetString(receiveBytes);
        //Console.WriteLine(Encoding.Default.GetString(receiveBytes));

    }
    private void LateUpdate()
    {
        //print(Encoding.Default.GetString(receiveBytes));
    }
    /*
    private void getmessage() // 메세지 받기
    {
        {
            stream = clientsocket.getstream();
            int buffersize = clientsocket.receivebuffersize;
            byte[] buffer = new byte[buffersize];
            int bytes = stream.read(buffer, 0, buffer.length);
            string message = encoding.unicode.getstring(buffer, 0, bytes);
            console.writeline(message);
        }

    }
    */
/*
    private void setpath()
    {
        string message = Encoding.Default.GetString(receiveBytes);
        string[] arr = message.Split(',');

        for (int i = 0; i < arr.Length; i++)
        {
            path[i] = Int32.Parse(arr[i]);
        }

        /*for (int i = 0; i < path.Length; i++)
        { 
            path[i] = 86 - i * 2;
            if (path[i] == 18)
                break;
        }
        
    }
}
*/