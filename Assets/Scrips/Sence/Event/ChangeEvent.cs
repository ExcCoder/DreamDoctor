using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeEvent : MonoBehaviour
{
    float change;
    public Image blackAndWrite;
    float write = 0;
    float black = 255;
    bool IsChange;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// ���볡���������ɺڱ��
    /// </summary>
    public void Enter()
    {
        if (change - Time.deltaTime * 10 < 0)
        {
            IsChange = false;
        }
        change += Time.deltaTime;
        blackAndWrite.color = new Color(0, 0, 0, change);
    }
    /// <summary>
    /// �˳�������������͸�����
    /// </summary>
    public void Exit()
    {
        change = change - Time.deltaTime * 10;
        if (change < 0)
        {
            IsChange = false;
        }
        change += Time.deltaTime;
        blackAndWrite.color = new Color(0, 0, 0, change);
    }
}
