using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : ManagerBase
{
    void Start()
    {
        MessageCenter.Instance.Register(this);
    }

  public override byte GetMessageType()
    {
        return MessageType.Type_UI;
    }
    
}
