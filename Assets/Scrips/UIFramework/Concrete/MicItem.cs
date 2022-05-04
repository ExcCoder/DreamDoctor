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

    }

}


