using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FSMState
{
    public int StateID;
    public MonoBehaviour Mono;
    public FSMManager FSMManager;

    public FSMState(int stateID, MonoBehaviour mono, FSMManager manager){
        StateID = stateID;
        Mono = mono;
        FSMManager = manager;
    }
    
    public abstract void OnEnter();

    public abstract void OnUpdate();
}
