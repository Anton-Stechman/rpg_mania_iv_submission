using System;
using UnityEngine;
using System.Collections;
using U3DT.Utils;
using U3DT.Library;
using System.Collections.Generic;

public class PlayerMotionInputHandler : Character {
    [SerializeField] private PlayerControls Controls = new PlayerControls();
    [SerializeField] private MouseLook MouseControl = new MouseLook();

    //Code Generated from U3DT Player Template; https://github.com/Anton-Stechman/U3DTools/tree/main
    private void Awake() {
        // execute on awake (before game start)
        Initialize();
        Controls.UpdateControlsConfig();
        MouseControl.Initialize(gameObject);
    }

    private void Start() {
        // execute on game start
    }

    private void FixedUpdate() {
        // physics
        MoveDirection = Direction();
        MoveInDirection();
    }

    private void Update() {
        // Other
        RotateThisObject(MouseControl.GetYRotation());
    }

    private void LateUpdate() {
        // camera
        MouseControl.CameraUpdate();
    }
    private Vector3 Direction() {
        Vector3 NewDirection = ForwardDirection();
        NewDirection += BackwardDirection();
        NewDirection += LeftDirection();
        NewDirection += RightDirection();
        return NewDirection;
    }
    private Vector3 ForwardDirection() {
        if(Input.GetKey(PlayerControlsConfig.GetKeyBindForward())) {
            return SetDirection(InputDirections.forward);
        }
        return SetDirection(InputDirections.zero);
    }
    private Vector3 BackwardDirection() {
        if(Input.GetKey(PlayerControlsConfig.GetKeyBindBackward())) {
            return SetDirection(InputDirections.back);
        }
        return SetDirection(InputDirections.zero);
    }
    private Vector3 RightDirection() {
        if(Input.GetKey(PlayerControlsConfig.GetKeyBindRight())) {
            return SetDirection(InputDirections.right);
        }
        return SetDirection(InputDirections.zero);
    }
    private Vector3 LeftDirection() {
        if(Input.GetKey(PlayerControlsConfig.GetKeyBindLeft())) {
            return SetDirection(InputDirections.left);
        }
        return SetDirection(InputDirections.zero);
    }
}