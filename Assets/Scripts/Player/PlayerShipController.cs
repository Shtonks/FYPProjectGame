using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipController : TopDownShipController
{
    private Vector2 lastPos;
    public float totalDistance = 0; // Currently resetting everytime after fuelBurnDistance is reached
    public float boost = 5f;
    
    private PlayerBehaviour pb;

    void Awake() 
    {
        pb = GetComponent<PlayerBehaviour>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        lastPos = transform.position;
        maxSpeed = pb.maxShipSpeed;
        accelerationFactor = pb.accelFactor;
    }

    private void Update() {
        maxSpeed = pb.maxShipSpeed;
        accelerationFactor = pb.accelFactor;
    }

    void FixedUpdate() 
    {
        ApplyEngineForce();

        StopOrthogonalVelocity();

        ApplySteering();

        TrackDistance();
    }

    // Makes the ship move forward/backward
    public override void ApplyEngineForce()
    {
        base.ApplyEngineForce();
        pb.speed = (int)base.speed;
    }

    public void SetInputVec(Vector2 inputVec)
    {
        if(getCanMove()) {
            steeringInput = inputVec.x;
            accelerationInput = inputVec.y;
        }
    }

    void TrackDistance() {
        float distance = Vector2.Distance( lastPos, transform.position ) ;
        totalDistance += distance ;
        lastPos = transform.position ;
        if(totalDistance >  fuelBurnDistance) {
            totalDistance = 0;
            pb.DecreaseFuel();
        }
    }


}
