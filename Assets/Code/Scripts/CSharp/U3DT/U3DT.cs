using System;
using System.Collections;
using UnityEngine;
public namespace U3DT {
    namespace Library {
        namespace Character {
            [System.Serializable] 
            public class Motion:MonoBehaviour {
                private CharacterController Controller;
                private float MoveSpeed = 5.00f;
                private float MaxSpeed = 10.00f;
                private float Mass = 2.00f;
                public Motion() {
                    SetMoveSpeed(MoveSpeed);
                    SetMaxSpeed(MaxSpeed);
                    SetMass(Mass);
                }
                public Motion(float NewMoveSpeed, float NewMaxSpeed, float NewMass, GameObject caller) {
                    SetMoveSpeed(NewMoveSpeed);
                    SetMaxSpeed(NewMaxSpeed);
                    SetMass(NewMass);
                    try {
                        Controller = caller.GetComponent<CharacterController>();
                    }
                    catch {
                        Controller = caller.AddComponent<CharacterController>();
                    }
                }
                public void SetMoveSpeed(float value) {
                    MoveSpeed = value;
                }
                public void SetMaxSpeed(float value) {
                    MaxSpeed = value;
                }
                public void SetMass(float value) {
                    Mass = value;
                }
                public CharacterController control() {
                    return Controller;
                }
            }
        }
    }
    namespace Utils {
        namespace UI {
            public class Control {

            }
        }
        public class ToolKit {
            public string Concatenate(string[] args, string delimiter = "\\") {
                result = string.Empty();
                for (int i = 0; i < args.Length; i++) {
                    if (i < args.Length) {
                        result += args[i] + delimiter; 
                    } else {
                        result += args[i];
                    }
                }
                return result;
            }
            public string Concatenate(char[] args, string delimiter = "\\") {
                result = string.Empty();
                for(int i = 0; i < args.Length; i++) {
                    if (i < args.Length) {
                        result += args[i] + delimiter; 
                    } else {
                        result += args[i];
                    }
                }
                return result;
            }
            public bool In(string value , string[] args) {
                foreach(string arg in args){
                    if(arg == value) {
                        return true;
                    }
                }
                return false;
            }
            public bool In(char value , char[] args) {
                foreach(char arg in args){
                    if(arg == value) {
                        return true;
                    }
                }
                return false;
            }
            public bool In(int value , int[] args) {
                foreach(int arg in args){
                    if(arg == value) {
                        return true;
                    }
                }
                return false;
            }
            public bool In(float value , float[] args) {
                foreach(float arg in args){
                    if(arg == value) {
                        return true;
                    }
                }
                return false;
            }
            public int Max(int[] args) {
                value = null;
                foreach(int arg in args) {
                    if(arg > value) {
                        value = arg;
                    }
                }
                return value;
            }
        }
    }
}
