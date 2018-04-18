using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyLog : MonoBehaviour {

    private string myLog;
    Queue myLogQueue = new Queue();
    int queueLenght = 30;

	// Use this for initialization
	void Start () {
        Debug.Log("Jugglia");
    }

    private void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    private void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    void HandleLog(string logString, string stackTrace, LogType type) {
        myLog = logString;
        string newString = "\n [" + type + "]" + myLog;
        myLogQueue.Enqueue(newString);

        if (type == LogType.Exception) {
            newString = "\n" + stackTrace;
            myLogQueue.Enqueue(newString);
        }

        while ( myLogQueue.Count >= queueLenght )
        {
            // Debug.Log("au dessus de 30");
            myLogQueue.Dequeue();
        }

        myLog = string.Empty;
        foreach (string mylog in myLogQueue) {
            myLog += mylog;
        }
    }

    void OnGUI () {
        GUI.color = Color.black;
        GUILayout.Label(myLog);
	}
}
