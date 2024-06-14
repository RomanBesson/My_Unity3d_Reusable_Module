using System.Collections;
using System.Collections.Generic;

    //背包格子
    public class InventoryItem{
        //物品id
        public int ItemId;
        //个数
        public int Count = 1;
    }

    public class InventoryManager : ManagersSingle<InventoryManager>
   {
   //背包集合
   public List<InventoryItem> Inventory = new List<InventoryItem>();

   //添加物品
    public void AddItem(int itemId, int count = 1){
        //查看背包中是否已经存在该物品
        foreach (InventoryItem tmpItem in Inventory){
        if (tmpItem.ItemId == itemId){
            //存在，就数量自增
            tmpItem.Count += count;
            return;
        }
        }
        //背包中不存在该物品
        InventoryItem item = new InventoryItem();
        item.ItemId = itemId;
        item.Count = count;
        Inventory.Add(item);
    }

    //移除物品
    public void Removeltem(int itemId, int count = 1){
    //遍历背包
    for (int i = 0; i < Inventory.Count; i++){
        InventoryItem item = Inventory[i];
        //如果存在该物品
        if (item.ItemId == itemId && item.Count > 0){
            //删除
            item.Count -= count;
            if (item.Count <= 0){
            Inventory.Remove(item);
            }  
        }
     }
    }
    
    //获取物品
    public InventoryItem GetItem(int itemId){
        foreach (InventoryItem tmpItem in Inventory){
            if (tmpItem.ItemId == itemId){
                return tmpItem;
            }
        }
        return null;
    }
    //清空背包
    public void RemoveAllItem() {
        Inventory.Clear();
    }
}
