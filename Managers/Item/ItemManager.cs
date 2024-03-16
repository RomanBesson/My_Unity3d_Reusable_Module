using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class Item
{
    public int id;
    public string name;
    public string des;
    public int price;
    public string icon;
    public int attack;
    public int hp;
}

public class ItemManager: ManagersSingle<ItemManager>
{
    //所有的物品信息
    private Item[] items;
    
    public ItemManager(){
        TextAsset json = Resources.Load<TextAsset>("Data/Item");
        //解析json
        items = LitJson.JsonMapper.ToObject<Item[]>(json.text);
    }
    
    //通过物品id获取物品
    public Item GetItem(int id){
        foreach (Item item in items){
            if(item.id == id) {
                return item;
            }
        }
        return null;
    }
}
