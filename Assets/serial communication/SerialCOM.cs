using UnityEngine;
using System.IO.Ports;
using System.Threading;
using System;


public class SerialCOM : MonoBehaviour
{

    private static SerialPort serial;
    private string[] portNames;
    private int t;
    private Thread _thread;
    private bool foundPort;
    public  int baudRate = 9600;
    public static string input;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start()
    {
       

        // Get the list of the ports that can be used and print them in the console
        portNames = SerialPort.GetPortNames();
        
        
        t = portNames.Length;
        for (int i = 0; i < t; i++)
        {
            // from all porst get the port that Contains string COM (which means the 1st available port)
            if (portNames[i].Contains("COM"))
            {

                if (CheckPort("\\\\.\\" + portNames[i]))
                {
                    print("Port is open: " + portNames[i] + " : " + serial.IsOpen);

                    foundPort = true;
                }
                break;
            }
        }
        if (foundPort)
        {
            if (serial.IsOpen)
            {

                _thread = new Thread(ThreadedWork);
                _thread.Start();

            }
        }
    }


    void ThreadedWork()
    {

        while (serial.IsOpen)
        {


            try
            {
                string buf = serial.ReadTo("\n");
                serial.DiscardOutBuffer();
                serial.DiscardInBuffer();
                input = buf;

                print(buf);

                // use Split to split your input string into string array
              //  string[] splitString = buf.Split('\t');

               
                Thread.Sleep(0);
            }
            catch (Exception e)
            {
                 Debug.LogError(e.GetBaseException());
            }
        }
    }

   
    

    public static void Write(string dataToSend)
    {
        if (serial.IsOpen)
        {
            try
            {

                serial.WriteLine(dataToSend);

            }
            catch (Exception e)
            {
                Debug.LogError(e.GetBaseException());
            }
        }
    }

        
    bool CheckPort(string portnName)
    {

        try
        {

            serial = new SerialPort(portnName, baudRate);

            if (!serial.IsOpen) serial.Open();

        }
        catch (Exception e)
        {
             Debug.LogError(e.GetBaseException());
        }

        if (serial.IsOpen && serial != null)
        {

            return true;
        }
        else
        {
            return false;
        }

    }

    void OnApplicationQuit()
    {

        if (serial != null)
        {
            if (serial.IsOpen)
               serial.Close();
        }
    }

}
