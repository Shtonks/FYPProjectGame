using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownShipController : MonoBehaviour
{
    public float accelerationFactor = 30.0f;
    public float turnFactor = 3.5f;
    public float driftFactor = 0.3f;
    public float maxSpeed = 20.0f;
    public float fuelBurnDistance = 200f;

    // Local vars
    protected float accelerationInput = 0;
    protected float steeringInput = 0;
    float rotationAngle = 0;
    protected float speed = 0;

    public bool canMove = true; // Says if the ship is currenty allowed to move
    
    protected Rigidbody2D rb;

    // Makes the ship move forward/backward
    public virtual void ApplyEngineForce()
    {
        // Calcs how much "forward" we are going terms of velocity
        speed = Vector2.Dot(transform.up, rb.velocity);

        // If hit maxSpeed, no more increase, just maintain
        if (speed > maxSpeed && accelerationInput > 0)
            return;

        // If hit half maxSpeed in reverse, no more increase, just maintain
        if (speed < -maxSpeed*0.25f && accelerationInput < 0)
            return;

        // Stops increasing speed in any direction while accelerating
        if (rb.velocity.sqrMagnitude > maxSpeed * maxSpeed && accelerationInput > 0)
            return;

        
        Vector2 engineForceVec = transform.up * accelerationInput * accelerationFactor;

        rb.AddForce(engineForceVec, ForceMode2D.Force);
    }

    protected void StopOrthogonalVelocity()
    {
        Vector2 forwardVelocity = transform.up * Vector2.Dot(rb.velocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(rb.velocity, transform.right);

        rb.velocity = forwardVelocity + rightVelocity * driftFactor;
    }

    protected void ApplySteering()
    {
        //Maybe don't use this if steering is too precise. Adding forces to chnage direction slowly may be better (and is recommeded by unity)

        rotationAngle -= steeringInput * turnFactor;

        rb.MoveRotation(rotationAngle);
    }

    public void setCanMove(bool b) {
        canMove = b;
    }

    public bool getCanMove() {
        return canMove;
    }
}
