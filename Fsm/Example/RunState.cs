using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : FSMState
{
    public RunState(int stateID, MonoBehaviour mono, FSMManager manager) : base(stateID, mono, manager)
    {
    }

    public override void OnEnter()
    {
        Mono.GetComponent<Animator>().SetFloat("Speed",5);
    }

    public override void OnUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(horizontal, 0, vertical);
        if (dir != Vector3.zero){
           Mono.transform.rotation = Quaternion.LookRotation(dir);
           Mono.transform.Translate(Vector3.forward * 5 * Time.deltaTime);
        }
        else {
            FSMManager.ChangeState((int)PlayState.idle);
        }
    }
}
