using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MoonBase
{
    public Text text;

    void Start() {
        UiManager.Instance.Register(this);
    }
    
    public override void ReceiveMessage(Message message){
        base.ReceiveMessage(message);
        
        if(message.Command == MessageType.UI_AddScore){
            int score = (int)message.Content;
            text.text = "分数" + score;
        }
    }
}
