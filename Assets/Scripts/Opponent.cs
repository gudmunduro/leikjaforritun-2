using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent : MonoBehaviour {

    public Rigidbody2D rb;

    private KeyCode[] keyCodes;
    private float[] times;
    private int current;
    private DrivingPhysics physics;

    private KeyCode currentKey
    {
        get
        {
            return keyCodes[current];
        }
    }

    private void Start () {
        physics = new DrivingPhysics(rb);

        SetArrays();
	}
	
	private void Update () {
        UpdateCurrent();

        if (currentKey == KeyCode.UpArrow)
        {
            physics.Accelerate();
        }
        if (currentKey == KeyCode.DownArrow)
        {
            physics.Reverse();
        }
        if (currentKey != KeyCode.DownArrow && currentKey != KeyCode.UpArrow)
        {
            physics.ResetForce();
        }
        UpdateCurrent();
        if (currentKey == KeyCode.LeftArrow)
        {
            physics.SteeringWheelPos = 5.0f;
        }
        else if (currentKey == KeyCode.RightArrow)
        {
            physics.SteeringWheelPos = -5.0f;
        }
        else
        {
            physics.SteeringWheelPos = 0;
        }
    }

    private void UpdateCurrent()
    {
        if (current < keyCodes.Length - 2 &&  times[current + 1] < Time.time)
        {
            current++;
        }
    }

    private void SetArrays()
    {
        keyCodes = new KeyCode[] {KeyCode.None, KeyCode.None, KeyCode.None, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow,
            KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow,
            KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.None, KeyCode.LeftArrow, KeyCode.None,
            KeyCode.LeftArrow, KeyCode.None, KeyCode.DownArrow, KeyCode.RightArrow, KeyCode.DownArrow, KeyCode.RightArrow, KeyCode.DownArrow, KeyCode.RightArrow, KeyCode.DownArrow, KeyCode.RightArrow, KeyCode.DownArrow, KeyCode.RightArrow, KeyCode.DownArrow,
            KeyCode.RightArrow, KeyCode.DownArrow, KeyCode.RightArrow, KeyCode.DownArrow, KeyCode.RightArrow, KeyCode.DownArrow, KeyCode.RightArrow, KeyCode.DownArrow, KeyCode.RightArrow, KeyCode.DownArrow, KeyCode.RightArrow, KeyCode.DownArrow,
            KeyCode.RightArrow, KeyCode.DownArrow, KeyCode.RightArrow, KeyCode.DownArrow, KeyCode.RightArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.DownArrow, KeyCode.LeftArrow,
            KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.DownArrow, KeyCode.None, KeyCode.LeftArrow,
            KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.UpArrow,
            KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow,
            KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.None, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow,
            KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow,
            KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow,
            KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow,
            KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow,
            KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow,
            KeyCode.UpArrow, KeyCode.None, KeyCode.LeftArrow, KeyCode.None, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow,
            KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow,
            KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow,
            KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.None, KeyCode.RightArrow, KeyCode.None, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow,
            KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow,
            KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow,
            KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow,
            KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow,
            KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow,
            KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, 
            KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.None, KeyCode.DownArrow, KeyCode.None, KeyCode.RightArrow, KeyCode.None, KeyCode.RightArrow, KeyCode.None, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow,
            KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow,
            KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, 
            KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow,
            KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow,
            KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow,
            KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow,
            KeyCode.None, KeyCode.RightArrow, KeyCode.None, KeyCode.UpArrow, KeyCode.None, KeyCode.RightArrow, KeyCode.None, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow,
            KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow,
            KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, 
            KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow,
            KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.None,
            KeyCode.RightArrow, KeyCode.None, KeyCode.UpArrow, KeyCode.None, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow,
            KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow,
            KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow,
            KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow,
            KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.RightArrow, 
            KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.None };

        times = new float[] { 2.08f, 2.1f, 2.12f, 2.42f, 2.58f, 2.6f, 2.6f, 2.62f, 2.62f, 2.64f, 2.64f, 2.66f, 2.66f, 2.68f, 2.68f, 2.7f, 2.7f, 2.72f, 2.96f, 2.98f, 2.98f, 3f, 3f, 3.02f, 3.02f, 3.04f, 3.04f, 3.06f, 3.06f, 3.08f, 3.08f, 3.1f, 3.32f, 3.34f, 3.34f, 3.36f,
            4.2f, 4.42f, 4.44f, 4.68f, 4.74f, 5.02f, 5.38f, 5.4f, 5.4f, 5.42f, 5.42f, 5.44f, 5.44f, 5.46f, 5.46f, 5.48f, 5.48f, 5.5f, 5.5f, 5.52f, 5.52f, 5.54f, 5.54f, 5.56f, 5.56f, 5.58f, 5.58f, 5.6f, 5.6f, 5.62f, 5.62f, 5.64f, 5.64f, 5.66f, 5.78f, 5.8f, 5.8f, 5.82f,
            5.82f, 5.84f, 5.84f, 5.86f, 5.86f, 5.88f, 5.88f, 5.9f, 5.9f, 5.92f, 5.92f, 5.94f, 5.94f, 5.96f, 6.12f, 6.14f, 6.22f, 6.22f, 6.24f, 6.24f, 6.26f, 6.26f, 6.28f, 6.28f, 6.3f, 6.56f, 6.58f, 6.58f, 6.92f, 6.92f, 6.94f, 6.94f, 6.96f, 6.96f, 6.98f, 6.98f, 7f, 7f,
            7.02f, 7.02f, 7.04f, 7.04f, 7.06f, 7.06f, 7.08f, 7.08f, 7.1f, 7.1f, 7.12f, 7.12f, 7.14f, 7.14f, 7.16f, 7.64f, 7.82f, 8.26f, 8.28f, 8.28f, 8.3f, 8.3f, 8.32f, 8.32f, 8.34f, 8.34f, 8.36f, 8.36f, 8.38f, 8.38f, 8.4f, 8.4f, 8.42f, 8.42f, 8.44f, 8.48f, 8.5f, 8.5f,
            8.52f, 8.52f, 8.54f, 8.54f, 8.559999f, 8.559999f, 8.58f, 8.58f, 8.599999f, 8.599999f, 8.62f, 8.62f, 8.639999f, 8.639999f, 8.66f, 8.66f, 8.679999f, 8.679999f, 8.7f, 8.7f, 8.72f, 8.72f, 8.74f, 8.74f, 8.76f, 8.76f, 8.78f, 8.94f, 8.96f, 8.96f, 8.98f, 8.98f, 9f,
            9f, 9.02f, 9.02f, 9.04f, 9.04f, 9.059999f, 9.62f, 9.639999f, 9.639999f, 9.66f, 9.66f, 9.679999f, 9.679999f, 9.7f, 9.7f, 9.719999f, 9.719999f, 9.74f, 9.88f, 10.08f, 10.16f, 10.46f, 10.64f, 10.64f, 10.66f, 10.66f, 10.68f, 10.68f, 10.7f, 10.7f, 10.72f, 10.72f,
            10.74f, 10.74f, 10.76f, 10.76f, 10.78f, 10.78f, 10.8f, 10.8f, 10.82f, 10.82f, 10.84f, 10.84f, 10.86f, 10.86f, 10.88f, 11f, 11.02f, 11.02f, 11.04f, 11.5f, 11.52f, 11.52f, 11.54f, 11.54f, 11.56f, 11.56f, 11.58f, 11.58f, 11.66f, 11.76f, 13.1f, 13.14f, 13.5f,
            13.52f, 13.52f, 13.54f, 13.54f, 13.56f, 13.56f, 13.58f, 13.58f, 13.6f, 13.6f, 13.62f, 13.62f, 13.64f, 13.64f, 13.66f, 13.66f, 13.68f, 13.84f, 13.86f, 13.86f, 13.88f, 13.88f, 13.9f, 13.9f, 13.92f, 13.92f, 13.94f, 13.94f, 13.96f, 13.96f, 13.98f, 13.98f, 14f,
            14f, 14.02f, 14.02f, 14.04f, 14.04f, 14.06f, 14.06f, 14.08f, 14.08f, 14.1f, 14.1f, 14.68f, 14.68f, 14.7f, 14.7f, 14.72f, 14.72f, 14.74f, 14.74f, 14.76f, 14.76f, 14.78f, 15.06f, 15.08f, 15.08f, 15.1f, 15.1f, 15.12f, 15.12f, 15.14f, 15.14f, 15.16f, 15.16f,
            15.18f, 15.18f, 15.2f, 15.2f, 15.22f, 15.22f, 15.24f, 15.32f, 15.34f, 15.34f, 15.36f, 15.36f, 15.38f, 15.38f, 15.4f, 15.4f, 15.42f, 15.42f, 15.44f, 15.44f, 15.46f, 15.46f, 15.48f, 15.48f, 15.5f, 15.5f, 15.52f, 15.52f, 15.9f, 16.68f, 16.7f, 16.88f, 17.78f,
            17.96f, 18.02f, 18.1f, 18.16f, 18.18f, 18.18f, 18.2f, 18.2f, 18.22f, 18.22f, 18.24f, 18.24f, 18.26f, 18.26f, 18.28f, 18.28f, 18.3f, 18.3f, 18.32f, 18.32f, 18.34f, 18.34f, 18.36f, 18.36f, 18.38f, 18.38f, 18.4f, 18.4f, 18.42f, 18.42f, 18.44f, 18.44f, 18.46f,
            18.46f, 18.48f, 18.48f, 18.5f, 18.5f, 18.52f, 18.52f, 18.54f, 18.54f, 18.56f, 18.56f, 18.58f, 18.58f, 18.6f, 18.6f, 18.62f, 18.62f, 18.64f, 18.82f, 18.84f, 18.84f, 18.86f, 18.86f, 18.88f, 19f, 19.02f, 19.02f, 19.04f, 19.04f, 19.06f, 19.06f, 19.08f, 19.08f,
            19.1f, 19.4f, 19.42f, 19.42f, 19.44f, 19.44f, 19.46f, 19.46f, 19.48f, 19.48f, 19.5f, 19.5f, 19.52f, 19.52f, 19.54f, 19.54f, 19.56f, 19.56f, 19.58f, 19.58f, 19.6f, 19.6f, 19.62f, 19.62f, 19.64f, 19.7f, 20.02f, 20.56f, 20.82f, 20.96f, 21.32f, 22.14f, 22.82f,
            22.92f, 22.94f, 22.94f, 22.96f, 22.96f, 22.98f, 22.98f, 23f, 23f, 23.02f, 23.02f, 23.04f, 23.04f, 23.06f, 23.06f, 23.08f, 23.08f, 23.1f, 23.1f, 23.12f, 23.12f, 23.14f, 23.14f, 23.16f, 23.16f, 23.18f, 23.18f, 23.2f, 23.2f, 23.22f, 23.22f, 23.24f, 23.24f,
            23.26f, 23.26f, 23.28f, 23.28f, 23.3f, 23.3f, 23.32f, 23.32f, 23.34f, 23.34f, 23.36f, 23.36f, 23.38f, 23.38f, 23.4f, 23.4f, 23.42f, 23.5f, 23.52f, 23.52f, 23.54f, 23.54f, 23.56f, 23.56f, 23.58f, 23.58f, 23.6f, 23.6f, 23.62f, 24.2f, 24.42f, 24.66f, 24.74f,
            24.92f, 25.32f, 25.52f, 25.54f, 25.54f, 25.56f, 25.56f, 25.58f, 25.58f, 25.6f, 25.6f, 25.62f, 26f, 26.02f, 26.02f, 26.04f, 26.04f, 26.06f, 26.06f, 26.08f, 26.08f, 26.1f, 26.1f, 26.12f, 26.12f, 26.14f, 26.14f, 26.16f, 26.16f, 26.18f, 26.18f, 26.2f, 26.2f,
            26.22f, 26.22f, 26.24f, 26.24f, 26.26f, 26.26f, 26.28f, 26.28f, 26.3f, 26.3f, 26.32f, 26.32f, 26.34f, 26.62f, 26.64f, 26.64f, 26.66f, 26.66f, 26.68f, 26.68f, 26.7f, 26.7f, 26.72f, 26.72f, 26.74f, 26.74f, 26.76f, 26.76f, 26.78f, 27.62f, 27.64f, 27.64f,
            27.66f, 27.66f, 27.68f, 27.68f, 27.7f, 28.06f, 30.06f };
    }
}
