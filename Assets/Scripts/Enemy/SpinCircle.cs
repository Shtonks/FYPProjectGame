using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinCircle : MonoBehaviour
{
    public float rotateSpeed = 10f;

    private void FixedUpdate() {
        transform.Rotate(Vector3.forward * rotateSpeed);
    }
}
