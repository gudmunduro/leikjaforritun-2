using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace carai
{
    public enum Action
    {
        None,
        Forward,
        Reverse,
        Left,
        Right,
        ForwardLeft,
        ForwardRight
    };

    public class CarAI
    {

        private Rigidbody2D rigidBody;
        private CheckpointManager checkpointManager;
        private int aa = 0;

        public Action action
        {
            get
            {
                Vector2 direction = (checkpointManager.nextCheckpoint - rigidBody.position).normalized; // Áttin sem checkpoint er í
                float carRotation = rigidBody.transform.rotation.eulerAngles.z + 90; // Snúningurinn á bílnum
                float directionDeg = Mathf.Acos((0.0f - direction.x) / 1.0f) * Mathf.Rad2Deg; // Áttin sem bíllin á að snúa til að fara í rétta átt
                if (Mathf.Abs(carRotation - directionDeg) > 10.0f) // Ef munurinn er minni en 10°
                {
                    if (carRotation < directionDeg)
                    {
                        return Action.ForwardLeft;
                    }
                    else
                    {
                        return Action.ForwardRight;
                    }
                }
                return Action.Forward;
            }
        }

        public CarAI(Rigidbody2D rigidBody, CheckpointManager checkpointManager)
        {
            this.rigidBody = rigidBody;
            this.checkpointManager = checkpointManager;
        }
    }
}