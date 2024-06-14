using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //状态机
    private FSMManager fSMManager;
    int score = 0;
    void Start()
    {
        fSMManager = new FSMManager();
        IdleState idleState = new IdleState(0, this, fSMManager);
        RunState  runState  = new RunState(1, this, fSMManager);
        WaveState waveState = new WaveState(2, this, fSMManager);

        fSMManager.StateList.Add(idleState);
        fSMManager.StateList.Add(runState);
        fSMManager.StateList.Add(waveState);
        
        fSMManager.ChangeState((int)PlayState.idle);
    }

    void Update()
    {
        fSMManager.Update();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Coin"){
            score += 1;
            Destroy(other.gameObject);
            Managers.m_UI.GetUIControl("score", "scores").ChangetText("分数：" +  score);
            //迟到金币音效
            Managers.m_Audio.PlaySeMusic("Voice/cilp", 1);
            // Managers.m_scene.LoadScene("SceneTwo", progress =>{
            //     Debug.Log(progress);
            // });
        }
    }
}
