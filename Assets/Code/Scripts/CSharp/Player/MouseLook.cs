using System;
using UnityEngine;
using System.Collections;
using U3DT.Utils;
using U3DT.Library;
using System.Collections.Generic;

[System.Serializable]
public class MouseLook {
    //Code Generated from U3DT Player Template; https://github.com/Anton-Stechman/U3DTools/tree/main
    [SerializeField] private Transform PlayerCamera;
    [SerializeField] private CameraFollow CameraPosition = new CameraFollow();
    [SerializeField] [Range(50.00f,150.00f)] private float xSensitivity = 50.00f;
    [SerializeField] [Range(50.00f,150.00f)] private float ySensitivity = 50.00f;
    [SerializeField] [Range(0.001f, 2.50f)] private float CameraFollowDampner = 0.015f;
    private float CurrentX = new float();
    private float CurrentY = new float();
    private Transform PlayerTransform;
    private GameObject PlayerObject;
    [SerializeField] private Transform FollowObject;

    public void Initialize(GameObject player) {
        GameSettings.SetSensitivity(xSensitivity, 'x');
        GameSettings.SetSensitivity(ySensitivity, 'y');
        if(PlayerCamera is null) {
            try {
                PlayerCamera = GameObject.FindWithTag("MainCamera").transform;
            }
            catch {
                Debug.Log("No Object Tagged as 'MainCamera'");
            }
        }

        PlayerObject = player;
        PlayerTransform = PlayerObject.transform;
        FollowObject.localPosition = SetTargetPosition();
    }

    private void CheckSettings() {
        if(xSensitivity != GameSettings.GetXSensitivity()) {
            xSensitivity = GameSettings.GetXSensitivity();
        }
        if(ySensitivity != GameSettings.GetYSensitivity()) {
            ySensitivity = GameSettings.GetYSensitivity();
        }
    }
    public void CameraUpdate() {
        CheckSettings();
        CurrentY = GetAxis('y');
        Vector3 CameraCurrentPos = PlayerCamera.position;
        PlayerCamera.position = Vector3.Lerp(CameraCurrentPos, FollowObject.transform.position, CameraFollowDampner * Time.deltaTime);
        LookAtPlayer();
    }
    public float GetYRotation() {
        if(!GameSettings.isPaused()) {
            return GetAxis('x') * xSensitivity;
        }
        return GetAxis('n');
    }
    private float GetAxis(char axis) {
        switch(axis) {
            case 'x': {
                return Input.GetAxis("Mouse X");
            }
            case 'y': {
                return Input.GetAxis("Mouse Y");
            }
            default: {
                return new float();
            }
        }
    }
    private Vector3 SetTargetPosition(Transform target = null) {
        if(target is null) {
            target = PlayerTransform;
        }
        return target.position + CameraPosition.GetOffSetTargetPosition();
    }
    private Vector3 GetTargetPosition(Transform target = null) {
        if(target is null) {
            target = PlayerTransform;
        }
        return target.position;
    }
    private void LookAtPlayer() {
        if(CameraPosition.GetLookAtPlayer()) {
            PlayerCamera.LookAt(GetTargetPosition());
        }
    }
}
[System.Serializable]
public class CameraFollow {
    [SerializeField] private bool LookAtPlayer = true;

    [SerializeField] private Vector3 OffSetTargetPosition = new Vector3(0, 2, -4);

    public bool GetLookAtPlayer() {
        return LookAtPlayer;
    }
    public Vector3 GetOffSetTargetPosition() {
        return OffSetTargetPosition;
    } 
}