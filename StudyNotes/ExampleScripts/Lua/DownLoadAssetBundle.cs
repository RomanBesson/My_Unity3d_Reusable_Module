using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

/// <summary>
/// 从服务器下载AssetBundle文件并写入到本地
/// </summary>
public class DownLoadAssetBundle : MonoBehaviour {

    /// <summary>
    /// 服务器文件夹路径
    /// </summary>
    private string mainAssetBundleURL = @"http://www.mkcode.net/mkdemo/AssetBundles/AssetBundles";
    /// <summary>
    /// 服务器文件路径
    /// </summary>
    private string allAssetBundelURL = @"http://www.mkcode.net/mkdemo/AssetBundles/";

	void Start () {
        StartCoroutine("DownLoadMainAssetBundel");
	}


    /// <summary>
    /// 下载主[目录]AssetBundle文件.
    /// </summary>
    /// <returns></returns>
    IEnumerator DownLoadMainAssetBundel()
    {
        //向服务器发送消息
        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(mainAssetBundleURL);
        

        yield return request.Send();

        //获取AssetBundle
        AssetBundle ab = DownloadHandlerAssetBundle.GetContent(request);

        //获取对应的文件目录
        AssetBundleManifest manifest = ab.LoadAsset<AssetBundleManifest>("AssetBundleManifest");

        //打印所有文件路径名称
        string[] names = manifest.GetAllAssetBundles();
        for (int i = 0; i < names.Length; i++)
        {
            Debug.Log(allAssetBundelURL + names[i]);
            //StartCoroutine(DownLoadSingleAssetBundel(allAssetBundelURL + names[i]));
            StartCoroutine(DownLoadAssetBundleAndSave(allAssetBundelURL + names[i]));
        }
    }

    /// <summary>
    /// 下载单个AssetBundle文件.
    /// </summary>
    IEnumerator DownLoadSingleAssetBundel(string url)
    {
        //向服务器发送消息
        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(url);
        yield return request.Send();

        //下载服务器中的资源
        AssetBundle ab = DownloadHandlerAssetBundle.GetContent(request);
        
        //打印资源中组件名称
        string[] names = ab.GetAllAssetNames();
        for (int i = 0; i < names.Length; i++)
        {
            string tempName = Path.GetFileNameWithoutExtension(names[i]);
            //Debug.Log(tempName);
            GameObject obj = ab.LoadAsset<GameObject>(tempName);
            GameObject.Instantiate<GameObject>(obj);
        }
    }

    /// <summary>
    /// 下载AssetBundle并且保存到本地.
    /// </summary>
    IEnumerator DownLoadAssetBundleAndSave(string url)
    {
        //下载对应路径的资源
        WWW www = new WWW(url);
        yield return www;

        //下载完毕后
        if (www.isDone)
        {
            //使用IO技术将www对象存储到本地.
            SaveAssetBundle(Path.GetFileName(url), www.bytes, www.bytes.Length);
        }
    }

    /// <summary>
    /// 存储AssetBundle为本地文件.
    /// </summary>
    private void SaveAssetBundle(string fileName, byte[] bytes, int count)
    {
        //创建文件，io流
        FileInfo fileInfo = new FileInfo(Application.streamingAssetsPath + "//" + fileName);
        FileStream fs = fileInfo.Create();

        //写入
        fs.Write(bytes, 0, count);
        fs.Flush();
        fs.Close();
        fs.Dispose();
        Debug.Log(fileName + "下载完毕~~~");
    }

}
