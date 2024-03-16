using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MyrSingletonBase<SceneManager>
{
    //场景名称
    public List<string> sceneList = new List<string>();
    //当前场景
    public int CurrentIndex = 0;
    //当前场景索引
    private System.Action<float> currentAction;
    //当前加载场景对象
    private AsyncOperation operation;
   
    public void LoadScene(string sceneName, System.Action<float> action){
        currentAction = action;
        if (sceneList.Contains(sceneName))
        {
            //更新场景索引
            CurrentIndex = sceneList.IndexOf(sceneName);
            //加载场景
            operation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName, UnityEngine.SceneManagement.LoadSceneMode.Single);
        }
    }

    void Update(){
        if (operation != null){
            
            currentAction(operation.progress);
            //场景加载完成
            if (operation.progress >= 1) operation = null;
        }
    }
    
    //加载上一个场景
    public void LoadPre(System.Action<float> action){
        CurrentIndex--;
        LoadScene(sceneList[CurrentIndex], action);
    }

    //加载上一个场景
    public void LoadNext(System.Action<float> action){
        CurrentIndex++;
        LoadScene(sceneList[CurrentIndex], action);
    }
}
