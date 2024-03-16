using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//对象池
public class PoolStack{
    //对象集合
    public Stack <UnityEngine.Object> stack = new Stack<Object>();
    //个数
    public int MaxCount = 100;
    
    //把游戏物体放入对象池
    public void Push(UnityEngine.Object go){
        if (stack.Count < MaxCount) stack.Push(go);
        else  GameObject.Destroy(go);
    }
    //从对象池取出对象
    public UnityEngine.Object Pop() {
        if (stack.Count > 0) return stack.Pop();
        return null;  
    }

    //清空池
    public void Clear(){
        foreach (UnityEngine.Object go in stack) GameObject.Destroy(go);
        stack.Clear();
    }

}

public class PoolManager :ManagersSingle<PoolManager>
{
    //管理多个池子
    Dictionary<string, PoolStack> poolDic = new Dictionary<string, PoolStack>();

    //从对象池取出对象，没有则创建一个
    public UnityEngine.Object Spawn(string poolName, UnityEngine.Object prefab){
        //如果没有对应的池子，创建池子
        if (!poolDic.ContainsKey(poolName)) poolDic.Add(poolName, new PoolStack());
        //从池子中拿出一个
        UnityEngine.Object go = poolDic[poolName].Pop();
        if (go == null) go = GameObject.Instantiate(prefab);
        return go;
    }
    //清空对象池
    public void UnSpawn(string poolName){
        if (poolDic.ContainsKey(poolName)){
            poolDic[poolName].Clear();
            poolDic.Remove(poolName);
        }
    }

}
