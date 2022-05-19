using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//�������ֵ��л�
public class MusicPanel : MonoBehaviour
{
    //��ȡ���ص�����
    AudioClip Clip;
    AudioSource Source;

    public Transform PushMusic;
    private void Start()
    {
        Source = GameObject.Find("Player").GetComponent<AudioSource>();
        
    }

    void FristPlay()
    {
        Source.clip = MusicLoad("��ѯ��-�ξ��ĸ�2");
        Source.Play();
    }
    //��ȡ��Ƭ���µ���������ʶ��Ҫ��ʲô����
    public void PlayMusic()
    {
        if (PushMusic.childCount > 0 && Source)
        {
            Debug.Log(PushMusic.GetChild(0).name);
            Source.clip = MusicLoad(PushMusic.GetChild(0).name);
            Source.Play();
        }
    }
    //�˳���ǰ���
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
