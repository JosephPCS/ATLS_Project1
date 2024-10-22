using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;

public class joystickMovement : MonoBehaviour
{
    public InputActionReference stickRef;
    [SerializeField]
    private GameObject playerOrigin;
    [SerializeField]
    private GameObject mainCamera;
    private float moveDist = .1f;
    private UnityEngine.Vector2 move;
    private UnityEngine.Vector3 forwardNoY;
    private UnityEngine.Vector3 rightNoY;

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(stickRef.action.ReadValue<UnityEngine.Vector2>());

        move = stickRef.action.ReadValue<UnityEngine.Vector2>();

        Debug.Log(move);

        //playerOrigin.transform.position += transform.forward * move[1];

        //movementVector = new UnityEngine.Vector3(move[0] * MathF.Cos(rotationDegrees[1] * Mathf.Deg2Rad), 0, move[1] * MathF.Cos(rotationDegrees[1] * Mathf.Deg2Rad));

        //playerOrigin.transform.position += moveDist * movementVector;

        //get curr rotation from 0
        //adjust vector by that much

        //locamotion unity package does something similar
        forwardNoY = new UnityEngine.Vector3(mainCamera.transform.forward[0], 0, mainCamera.transform.forward[2]);
        rightNoY = new UnityEngine.Vector3(mainCamera.transform.right[0], 0, mainCamera.transform.right[2]);

        playerOrigin.transform.position += forwardNoY * move[1] * moveDist;
        playerOrigin.transform.position += rightNoY * move[0] * moveDist;
    }
}
