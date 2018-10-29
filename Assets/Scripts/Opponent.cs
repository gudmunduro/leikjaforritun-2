using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using carai;

public class Opponent : MonoBehaviour {

    public Rigidbody2D rb;
    public GameController gameController;

    private DrivingPhysics physics;
    private CheckpointManager checkpointManager;
    private CarAI carAI;

    private void Start () {
        physics = new DrivingPhysics(rb);
        checkpointManager = new CheckpointManager(rb);
        carAI = new CarAI(rb, checkpointManager);
	}
	
	private void Update () {
        if (!checkpointManager.isAtLastCheckpoint && checkpointManager.isNearNextCheckpoint)
        {
            checkpointManager.Update();
            if (checkpointManager.isAtLastCheckpoint)
            {
                gameController.OnFinishLineEnter("player");
            }
        }

        if (carAI.action == Action.Forward || carAI.action == Action.ForwardLeft || carAI.action == Action.ForwardRight)
        {
            physics.Accelerate();
        }
        if (carAI.action == Action.Reverse)
        {
            physics.Reverse();
        }
        if (carAI.action == Action.Forward || carAI.action != Action.Forward || carAI.action != Action.None)
        {
            physics.ResetForce();
        }
        if (carAI.action == Action.Left || carAI.action == Action.ForwardLeft)
        {
            physics.SteeringWheelPos = 5.0f;
        }
        else if (carAI.action == Action.Right || carAI.action == Action.ForwardRight)
        {
            physics.SteeringWheelPos = -5.0f;
        }
        else
        {
            physics.SteeringWheelPos = 0;
        }
    }

}
