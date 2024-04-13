using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageCenter : MyrSingletonBase<MessageCenter>
{
    public List<ManagerBase> Managers = new List<ManagerBase>();

    public void Register(ManagerBase manager){
        if (!Managers.Contains(manager)){
            Managers.Add(manager);
        }
    }

    public void SendCustomMessage(Message message){
        foreach(var manager in Managers){
            manager.ReceiveMessage(message);
        }
    }
}
