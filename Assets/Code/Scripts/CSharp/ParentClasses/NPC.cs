using System;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using U3DT.Utils;
using U3DT.Library;
using System.Collections.Generic;

[RequireComponent(typeof(NavMeshAgent))]
public class Character : MonoBehaviour {

    [SerializeField] private NPCType npcType = NPCType.friendly;
    [SerializeField] private int npcLevel = 1;
    [SerializeField] private int BaseHealth = 25;
    [SerializeField] private int BaseDamage = 2;

    const int MaximumHealth = 100;
    const int MaximumDamage = 20;
    private int MaxHealth() {
        int result = BaseHealth;
        if(npcLevel > 1) {
            result = BaseHealth * npcLevel;
            return ToolKit.Clamp(result, MaximumHealth);
        }
        return result;
    }
    private int MaxDamage() {
        int result = BaseDamage;
        if(npcLevel > 1) {
            result = BaseDamage * npcLevel;
            return ToolKit.Clamp(result, MaximumDamage);
        }
        return result;
    }
    private float CurrentHealth;
    
    //Code Generated from U3DT Player Template; https://github.com/Anton-Stechman/U3DTools/tree/main
    public void Initialize() {
        // execute on awake (before game start)
        CurrentHealth = (float)MaxHealth();

    }


}

public enum NPCType {
    hostile
    , friendly
    , neutral
}

