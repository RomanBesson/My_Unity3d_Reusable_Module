using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ManagerBase : MyrSingletonBase<ManagerBase>
{
   public List<MoonBase> Monos = new List<MoonBase>();

   public void Register(MoonBase mono){
    if (!Monos.Contains(mono)){
        Monos.Add(mono);
    }
   }
   
   public virtual void ReceiveMessage(Message message){
    if (message.Type != GetMessageType()){
        return;
    }
    foreach (var mono in Monos){
        mono.ReceiveMessage(message);
    }
   }
   
   public abstract byte GetMessageType();
}
