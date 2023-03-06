using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    PlayerShipController controller;

    void Awake() 
    {
        controller = GetComponent<PlayerShipController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVec = Vector2.zero;

        inputVec.x = Input.GetAxis("Horizontal");
        inputVec.y = Input.GetAxis("Vertical");

        controller.SetInputVec(inputVec);
    }
}
