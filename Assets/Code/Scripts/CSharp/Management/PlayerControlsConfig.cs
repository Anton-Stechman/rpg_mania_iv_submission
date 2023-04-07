using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using U3DT.Utils;

public static class PlayerControlsConfig {
    
    private static KeyCode Forward;
    private static KeyCode Backward;
    private static KeyCode Left;
    private static KeyCode Right;

    //Set Keybinds
    public static void SetKeyBindForward(KeyCode key) {
        Forward = key;
    }
    public static void SetKeyBindBackward(KeyCode key) {
        Backward = key;
    }
    public static void SetKeyBindLeft(KeyCode key) {
        Left = key;
    }
    public static void SetKeyBindRight(KeyCode key) {
        Right = key;
    }

    //Get Keybinds
    public static KeyCode GetKeyBindForward() {
        return Forward;
    }
    public static KeyCode GetKeyBindBackward() {
        return Backward;
    }
    public static KeyCode GetKeyBindLeft() {
        return Left;
    }
    public static KeyCode GetKeyBindRight() {
        return Right;
    }
}

[System.Serializable]
public class PlayerControls {
    [SerializeField] private KeyCode Forward = KeyCode.W;
    [SerializeField] private KeyCode Backward = KeyCode.S;
    [SerializeField] private KeyCode Left = KeyCode.A;
    [SerializeField] private KeyCode Right = KeyCode.D;

    public PlayerControls() {
        UpdateControlsConfig();
    }

    public PlayerControls (KeyCode fwd, KeyCode bck, KeyCode lft, KeyCode rht) {
        Forward = fwd;
        Backward = bck;
        Left = lft;
        Right = rht;
        UpdateControlsConfig();
    }
    
    public void UpdateControlsConfig() {
        PlayerControlsConfig.SetKeyBindForward(Forward);
        PlayerControlsConfig.SetKeyBindBackward(Backward);
        PlayerControlsConfig.SetKeyBindLeft(Left);
        PlayerControlsConfig.SetKeyBindRight(Right);
    }
}