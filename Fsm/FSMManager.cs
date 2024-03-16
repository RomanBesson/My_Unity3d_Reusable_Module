using System.Collections;
using System.Collections.Generic;

public class FSMManager
{
   public List<FSMState> StateList = new List<FSMState>();
   public int CurrentIndex = -1;

   public void ChangeState(int StateID){
      CurrentIndex = StateID;
      StateList[CurrentIndex].OnEnter(); 
   }

   public void Update() {
      if (CurrentIndex != -1){
        StateList[CurrentIndex].OnUpdate();
      }
   }
}
