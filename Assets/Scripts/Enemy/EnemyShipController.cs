using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipController : TopDownShipController
{
    void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() 
    {
        ApplyEngineForce();

        StopOrthogonalVelocity();

        ApplySteering();
    }
}
