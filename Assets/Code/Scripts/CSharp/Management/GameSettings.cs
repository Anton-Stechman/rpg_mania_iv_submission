using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using U3DT.Utils;

public static class GameSettings {
    private static RunState GameState = RunState.running;
    private static float xSensitivity;
    private static float ySensitivity;
    public static void ToggleGameState() { 
        if(isPaused()) {
            GameState = RunState.running;
        }
        else {
            GameState = RunState.paused;
        }
    }
    public static bool isPaused() {
        return GameState == RunState.paused;
    }
    public static void SetSensitivity(float val, char axis) {
        switch(axis) {
            case 'x': {
                xSensitivity = val;
                break;
            }
            default: {
                ySensitivity = val;
                break;
            }
        }
    }
    public static void SetSensitivity(float val) {
        xSensitivity = val;
        ySensitivity = val;
    }
    public static float GetXSensitivity() {
        return xSensitivity;
    }
    public static float GetYSensitivity() {
        return ySensitivity;
    }
}
public enum RunState {
    paused
    , running
}