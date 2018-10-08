using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrivingPhysics  // Mjög lélegt drving physics sem ég gerði fyrir leikinn
{
    public Rigidbody2D rb;
    public float maxForwardForce;
    public float maxBackwardForce;

    private Vector3 toRotation;
    private Vector3 currentRoation;

    public float SteeringWheelPos // Þarf alltaf að breyta í update svo það virki rétt
    {
        set
        {
            toRotation.z += value;
            currentRoation = Vector3.Lerp(currentRoation, toRotation, Time.deltaTime);
            rb.transform.localEulerAngles = currentRoation;
        }
    }
    public float TurningDeg
    {
        get
        {
            return toRotation.z;
        }
    }
    

    public DrivingPhysics(Rigidbody2D rb)
    {
        this.rb = rb;

        toRotation = new Vector3(0, 0, 90);
        currentRoation = new Vector3(0, 0, 0);

        maxForwardForce = 200.0f;
        maxBackwardForce = 50.0f;
    }

    public void Accelerate()
    {
        rb.AddRelativeForce(forwardForce);
    }

    public void Reverse()
    {
        rb.AddRelativeForce(backwardForce);
    }

    public void ResetForce()
    {
        force = 0;
    }

    // Private

    private float force = 0;

    private Vector3 forwardForce
    {
        get
        {
            if (force < maxForwardForce) force += 10.0f;
            return new Vector3(0.0f, force * -1, 0.0f);
        }
    }

    private Vector3 backwardForce
    {
        get
        {
            if (force < maxBackwardForce) force += 10.0f;
            return new Vector3(0.0f, force / 4, 0.0f);
        }
    }

    private Vector2 getDirection(float deg)
    {
        float rad = deg * Mathf.PI / 180;
        return new Vector2(0 + 1 * Mathf.Cos(rad), 0 + 1 * Mathf.Sin(rad));
    }
}
