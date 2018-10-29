using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Rigidbody2D rigidBody;
    public GameController gameController;
    public AudioClip idle;
    public AudioClip accelerating;
    public AudioSource audioSource;

    private DrivingPhysics physics;
    private CheckpointManager checkpointManager;

	void Start () {
        physics = new DrivingPhysics(rigidBody);
        checkpointManager = new CheckpointManager(rigidBody);
	}

    private void Update()
    {
        if (!checkpointManager.isAtLastCheckpoint && checkpointManager.isNearNextCheckpoint)
        {
            checkpointManager.Update();
            if (checkpointManager.isAtLastCheckpoint)
            {
                gameController.OnFinishLineEnter("player");
            }
        }
    }

    void FixedUpdate () {

        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("X: " + rigidBody.position.x + ", Y: " + rigidBody.position.y);
        }

		if (Input.GetKey(KeyCode.UpArrow))
        {
            if (audioSource.clip != accelerating)
            {
                audioSource.clip = accelerating;
                audioSource.Play();
            }
            physics.Accelerate();
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (audioSource.clip != accelerating)
            {
                audioSource.clip = accelerating;
                audioSource.Play();
            }
            physics.Reverse();
        }
        if (!Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow))
        {
            if (audioSource.clip != idle)
            {
                audioSource.clip = idle;
                audioSource.Play();
            }
            physics.ResetForce();
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            physics.SteeringWheelPos = 5.0f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            physics.SteeringWheelPos = -5.0f;
        }
        else
        {
            physics.SteeringWheelPos = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D with)
    {
        Debug.Log("Collision!");
    }
}
