using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MyrSingletonBase<AudioManager>
{
    //环境音
    private AudioSource enPlayer;
    //音效
    private AudioSource sePlayer;
    //音乐
    private AudioSource Player;

    void Start() {
        //初始化
        Player = gameObject.AddComponent<AudioSource>();
        Player.loop = true;
        sePlayer = gameObject.AddComponent<AudioSource>();
        enPlayer = gameObject.AddComponent<AudioSource>();
        GameObject.DontDestroyOnLoad(gameObject);
    }

#region 声音部分
    //通过文件名找到对应音频，并播放
    public void PlayMusic(string name, float volume = 1){
        AudioClip clip = Resources.Load<AudioClip>(name);
        PlayMusic(clip, volume);
    }

    public void PlayMusic(AudioClip clip, float volume = 1){
        if (Player.isPlaying) {
            Player.Stop();
        }
        //音量大小
        Player.volume = volume;
        Player.clip = clip;
        Player.Play();
    }
    
    public void StopMusic() {
        Player.Stop();
    }

    //改变声音
    public void ChangeMusicVolume(float volume) {
        Player.volume = volume;
    }
#endregion

#region 环境音部分
    //播放环境音
    public void PlayEnMusic(string name, float volume = 1){
        AudioClip clip = Resources.Load<AudioClip>(name);
        PlayEnMusic(clip, volume);
    }

    public void PlayEnMusic(AudioClip clip, float volume = 1){
        if (enPlayer.isPlaying) {
            enPlayer.Stop();
        }
        //音量大小
        enPlayer.volume = volume;
        enPlayer.clip = clip;
        enPlayer.Play();
    }
    
    //停止环境音
    public void StopEnMusic() {
        enPlayer.Stop();
    }

    public void ChangeEnMusicVolume(float volume) {
        enPlayer.volume = volume;
    }
#endregion

#region 音效部分
    public void PlaySeMusic(string name, float volume = 1){
        AudioClip clip = Resources.Load<AudioClip>(name);
        PlaySeMusic(clip, volume);
    }

    public void PlaySeMusic(AudioClip clip, float volume = 1){
        sePlayer.PlayOneShot(clip, volume);
    }
#endregion

#region 环绕物体音
    public void PlaySeSoundOnObject(string name, GameObject go, float volume = 1){
        AudioClip clip = Resources.Load<AudioClip>(name);
        PlaySeSoundOnObject(clip, go, volume);
    }

    public void PlaySeSoundOnObject(AudioClip clip, GameObject go, float volume = 1){
        AudioSource player =go.GetComponent<AudioSource>();
        if(player == null) {
            player = go.AddComponent<AudioSource>();
        }
        player.volume = volume;
        player.PlayOneShot(clip);
    }
#endregion
}
