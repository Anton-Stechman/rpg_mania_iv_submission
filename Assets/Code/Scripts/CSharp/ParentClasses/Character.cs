using System;
using UnityEngine;
using System.Collections;
using U3DT.Utils;
using U3DT.Library;
using System.Collections.Generic;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour {

    [SerializeField] [Range(0,10)] private int PlayerMassFactor = 5;
    [SerializeField] [Range(0,30)] private float PlayerAccelerationFactor = 5.00f;
    [SerializeField] [Range(0,15)] private float PlayerMaxVelocity = 2.50f;
    [SerializeField] [Range(0.00f, 1.50f)] private float SmoothRotation = 0.0075f;

    [HideInInspector] public Vector3 MoveDirection = new Vector3();
    private float CurrentVelocity = 0.00f;

    private CharacterController controller;
    
    //Code Generated from U3DT Player Template; https://github.com/Anton-Stechman/U3DTools/tree/main
    public void Initialize() {
        // execute on awake (before game start)
        try {
            controller = gameObject.GetComponent<CharacterController>();
        }
        catch {
            controller = gameObject.AddComponent<CharacterController>();
        }
    }

    private void FixedUpdate() {
        // physics
        CurrentVelocity = controller.velocity.magnitude;
        MoveInDirection();
    }

    private void Update() {
        // Other
    }

    public void MoveInDirection() {
        if (CurrentVelocity < PlayerMaxVelocity) {
            controller.Move(MoveDirection * PlayerAccelerationFactor * Time.deltaTime);
        }
    }
    private void ApplyGravity() {
        controller.Move(Down() * PlayerMassFactor * Time.deltaTime);
    }
    private Vector3 Down() {
        return -transform.up;
    }
    public Vector3 SetDirection(InputDirections dir) {
        switch(dir) {
            case InputDirections.forward: {
                return transform.forward;
            }
            case InputDirections.back: {
                return -transform.forward;
            }
            case InputDirections.right: {
                return transform.right;
            }
            case InputDirections.left: {
                return -transform.right;
            }
            default: {
                break;
            }
        }
        return new Vector3();
    }
    public void RotateThisObject(float yRotation) {
        /*Quaternion CurrentRotation = transform.rotation;
        float xRot = CurrentRotation.x;
        float yRot = CurrentRotation.y * yRotation;
        float zRot = CurrentRotation.z;
        Quaternion NextRotation = new Quaternion(xRot, yRot, zRot, 0);
        transform.rotation = Quaternion.Slerp(CurrentRotation, NextRotation, SmoothRotation);*/
        gameObject.transform.Rotate(transform.up * yRotation * Time.deltaTime);
    }
}

public enum InputDirections {
    forward
    , back
    , left
    , right
    , zero
}