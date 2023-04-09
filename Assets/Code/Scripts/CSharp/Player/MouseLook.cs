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
    [SerializeField] [Range(0.01f, 2.50f)] private float CameraFollowDampner = 1.20f;
    private float CurrentX = new float();
    private float CurrentY = new float();
    private Transform PlayerTransform;
    private GameObject PlayerObject;
    [SerializeField] private GameObject FollowObject;

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
        FollowObject.transform.position = SetPosition();
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
        // FollowObject.transform.position = SetPosition();
        FollowObject.transform.localPosition = CameraPosition.GetOffsetPosition();
        PlayerCamera.position = Vector3.Lerp(CameraCurrentPos, FollowObject.transform.position, CameraFollowDampner);
        CameraVerticalRotation();
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
    private Vector3 SetPosition(Transform target = null) {
        return PlayerTransform.position + CameraPosition.GetOffsetPosition();
    }
    private Vector3 GetPosition(Transform target = null) {
        if(target is null) {
            target = PlayerTransform;
        }
        return target.position;
    }
    private void CameraVerticalRotation() {
        //https://answers.unity.com/questions/862380/how-to-slow-down-transformlookat.html
        PlayerCamera.Rotate(PlayerCamera.right * CurrentY * Time.deltaTime);
        if(CameraPosition.GetLookAtPlayer()) {
            PlayerCamera.LookAt(GetPosition());
        }
    }
}
[System.Serializable]
public class CameraFollow {
    [SerializeField] private bool LookAtPlayer = true;

    [SerializeField] private Vector3 OffsetPosition = new Vector3(0, 2, -4);

    public bool GetLookAtPlayer() {
        return LookAtPlayer;
    }
    public Vector3 GetOffsetPosition() {
        return OffsetPosition;
    } 
}