using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Rigidbody2D rb;
    private DrivingPhysics physics;

    private Recorder recorder;

	void Start () {
        physics = new DrivingPhysics(rb);

        recorder = new Recorder();
	}
	
	void FixedUpdate () {

		if (Input.GetKey(KeyCode.UpArrow))
        {
            recorder.KeyDown(KeyCode.UpArrow);
            physics.Accelerate();
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            recorder.KeyDown(KeyCode.DownArrow);
            physics.Reverse();
        }
        if (!Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow))
        {
            physics.ResetForce();
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            recorder.KeyDown(KeyCode.LeftArrow);
            physics.SteeringWheelPos = 5.0f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            recorder.KeyDown(KeyCode.RightArrow);
            physics.SteeringWheelPos = -5.0f;
        }
        else
        {
            physics.SteeringWheelPos = 0;
        }

        if (!Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            recorder.KeyDown(KeyCode.None);
        }
    }

    void OnCollisionEnter2D(Collision2D with)
    {
        Debug.Log("!");
    }
}
