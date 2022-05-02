using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowAiun : MonoBehaviour
{
    private RectTransform Aiun;
    public Text text;
    bool IsShow = false;
    int count = 1;
    bool Pause = true;
    private void Start()
    {
        Aiun = this.gameObject.GetComponent<RectTransform>();
        text.text = "《";
    }
    void Update()
    {
        if (IsShow&&!Pause)
        {
            Aiun.transform.Translate(new Vector3(10, 0, 0) * -50 * Time.deltaTime);

            if (Aiun.anchoredPosition.x < 700)
            {
                Pause = true;
            }

        }
        if (!IsShow&&!Pause)
        {
            Aiun.transform.Translate(new Vector3(10, 0, 0) * 50 * Time.deltaTime);
            if (Aiun.anchoredPosition.x > 923)
            {
                Pause = true;
            }
            
        }
    }
    public void Clicl()
    {
        Pause = false;
        Debug.Log("点击了展示窗体");
        //展开
        if (count==1)
        {
            count++;
            IsShow = true;
            text.text = "》";
        }else
        //收起
        if (count==2)
        {
                text.text = "《";
                IsShow = false;
                count = 1;
        }
    }
}
