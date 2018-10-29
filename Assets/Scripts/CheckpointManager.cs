using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager {

    private Rigidbody2D rb;
    public Vector2[] checkpoints;
    public int currentCheckpointIndex;

    public CheckpointManager(Rigidbody2D rbOfObject)
    {
        checkpoints = new Vector2[6] {
                                       new Vector2(152.994f, -0.710f),
                                       new Vector2(90.385f, 28.633f),
                                       new Vector2(95.108f, 84.542f),
                                       new Vector2(-20.080f, 87.054f),
                                       new Vector2(-19.700f, 0.934f),
                                       new Vector2(36.825f, 2.850f)
        };

        rb = rbOfObject;
        currentCheckpointIndex = -1;
    }

    public Vector2 nextCheckpoint
    {
        get
        {
            return checkpoints[nextCheckpointIndex];
        }
    }

    public bool isNearNextCheckpoint
    {
        get
        {
            if (isAtLastCheckpoint) return false;
            return Vector2.Distance(rb.position, nextCheckpoint) < 10.0f;
        }

    }

    public int nextCheckpointIndex
    {
        get
        {
            return currentCheckpointIndex + 1;
        }
    }

    public bool isAtLastCheckpoint
    {
        get
        {
            return currentCheckpointIndex >= checkpoints.Length - 1;
        }
    }

    public void Update()
    {
        if (isNearNextCheckpoint)
        {
            Debug.Log("Next");
            currentCheckpointIndex++;
        }
    }
}
