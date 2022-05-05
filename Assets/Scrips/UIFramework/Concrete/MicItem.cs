using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MicItem : BasePanel
{
    static readonly string path = "Prefabs/UI/Panel/MicItemVariant";
    public MicItem() : base(new UIType(path)) { }
    public override void OnEnter()
    {
        Transform PushMic = UITool.FindChildGameObject("PushMusic").transform;
        Transform red = UITool.FindChildGameObject("Redrecode").transform;
        Transform green = UITool.FindChildGameObject("GreenRecode").transform;
        Transform oringin = UITool.FindChildGameObject("OringinRecode").transform;
        Transform blue = UITool.FindChildGameObject("BlueRecode").transform;
        UITool.GetOrAddComponentInChild<Button>("RedRecode").onClick.AddListener(() => {
            UITool.FindChildGameObject("Redrecode").transform.parent= UITool.FindChildGameObject("PushMusic").transform;
            UITool.FindChildGameObject("Redrecode").transform.Translate(0,0,0);

        });
    }

}


