using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//控制音乐的切换
public class MusicPanel : MonoBehaviour
{
    //获取加载的音乐
    AudioClip Clip;
    AudioSource Source;

    public Transform PushMusic;
    private void Start()
    {
        Source = GameObject.Find("Player").GetComponent<AudioSource>();
        
    }

    void FristPlay()
    {
        Source.clip = MusicLoad("咨询室-梦境的歌2");
        Source.Play();
    }
    //获取唱片机下的子物体以识别要放什么音乐
    public void PlayMusic()
    {
        if (PushMusic.childCount > 0 && Source)
        {
            Debug.Log(PushMusic.GetChild(0).name);
            Source.clip = MusicLoad(PushMusic.GetChild(0).name);
            Source.Play();
        }
    }
    //退出当前面板
    public void ExitPanel()
    {
        MusicTrigger.manage.Pop();
        Time.timeScale = 1;
        MusicTrigger.isShow = true;
        College2DReturn.isPush = true;
    }
    public void PauseMusic()
    {
        if (Source)
        {
            Source.Pause();
        }
    }
    private void Update()
    {

    }
    void showMusicName()
    {

    }
    AudioClip MusicLoad(string ID)
    {
        return Resources.Load<AudioClip>("Audio/" + ID);
    }


}
