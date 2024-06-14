using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveState : FSMState
{
    public WaveState(int stateID, MonoBehaviour mono, FSMManager manager) : base(stateID, mono, manager)
    {
    }

    public override void OnEnter()
    {
        Mono.GetComponent<Animator>().SetBool("Rest",true);
    }

    public override void OnUpdate()
    {
        if(!Mono.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Rest")){
            FSMManager.ChangeState((int)PlayState.idle);
            Mono.GetComponent<Animator>().SetBool("Rest",false);
        }
    }
}
