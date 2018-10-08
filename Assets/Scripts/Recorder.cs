using System;
using System.Collections.Generic;
using UnityEngine;


class Recorder
{
    private KeyCode[] keyCodes;
    private float[] times;
    private int current;
    private bool running;

    private KeyCode lastKey
    {
        get
        {
            return (current > 0) ? keyCodes[current] : KeyCode.None;
        }
    }

    public Recorder(int maxLength = 1000)
    {
        keyCodes = new KeyCode[maxLength];
        times = new float[maxLength];
        current = -1;
        running = false;
    }

    // Public föll

    public void Start()
    {
        running = true;
    }

    public void Pause()
    {
        running = false;
    }

    public void Reset()
    {
        running = false;
        times = new float[times.Length];
        keyCodes = new KeyCode[keyCodes.Length];
        current = 0;
    }

    public void KeyDown(KeyCode keyCode)
    {
        if (!running) return;
        if (lastKey != keyCode)
        {
            Update(keyCode);
        }
    }

    public void LogToConsole()
    {
        Debug.Log(KeyCodesToString(keyCodes));
        Debug.Log(FloatsToString(times));
    }


    // Aðeins fyrir notkun innan úr klasanum

    private void Update(KeyCode keyCode)
    {
        current++;
        times[current] = Time.time;
        keyCodes[current] = keyCode;
    }

    private string KeyCodesToString(KeyCode[] keyCodes)
    {
        string str = "[ ";
        for (int i = 0; i < keyCodes.Length; i++)
        {
            str += "KeyCode." + keyCodes[i].ToString() + ", ";
        }
        return str;
    }

    private string FloatsToString(float[] floats)
    {
        string str = "[ ";
        for (int i = 0; i < floats.Length; i++)
        {
            str += floats[i].ToString() + ", ";
        }
        return str;
    }
}

