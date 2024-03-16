using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message 
{
   public byte Type;
   public int Command ;
   public object Content;
   public Message() {}
   
   public Message(byte type, int command, object content) {
       Type = type;
       Command = command;
       Content = content;
   }
}
//消息类型
public class MessageType
{
    //类型
    public static byte Type_Audio = 1;
    public static byte Type_UI = 2;
    public static byte Type_Player = 3;
//声音命令
    public static int Audio_PlaySound = 100;
    public static int Audio_StopSound = 101;
    public static int Audio_PlayMusic = 102;
//UI命令
    public static int UI_ShowPanel = 200;
    public static int UI_AddScore = 201;
    public static int UI_ShowShop = 202;

}