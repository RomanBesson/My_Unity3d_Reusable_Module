using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : FSMState
{
    public IdleState(int stateID, MonoBehaviour mono, FSMManager manager) : base(stateID, mono, manager)
    {
    }

    public override void OnEnter()
    {
        Mono.GetComponent<Animator>().SetFloat("Speed", 0);
    }

    public override void OnUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(horizontal, 0, vertical);
        if (dir != Vector3.zero){
           FSMManager.ChangeState((int)PlayState.run);
        }

        if (Input.GetKeyDown(KeyCode.Space)){
            FSMManager.ChangeState((int)PlayState.wave);
        }
    }
}
