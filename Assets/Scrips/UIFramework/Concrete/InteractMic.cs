using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractMic : BasePanel
{
    static readonly string path = "Prefabs/UI/Panel/MicInteract";
    public InteractMic() : base(new UIType(path)) { }
    public override void OnEnter()
    {
        UITool.GetOrAddComponentInChild<Button>("MicChange").onClick.AddListener(() =>
        {
            Pop();
            Push(new PousePanel());
        });
        UITool.GetOrAddComponentInChild<Button>("MicClick").onClick.AddListener(() =>
        {
            
        });
    }

}


