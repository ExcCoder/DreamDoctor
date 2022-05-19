using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowMSG : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Transform CurDisc;
    public Transform Parent;
    
    public void Change()
    {
        if (!this.GetComponentInParent<SpriteRenderer>())
        {
            CurDisc = Parent.GetChild(0);
            var temp = this.transform.position;
            this.transform.position = CurDisc.position;
            CurDisc.parent = this.transform.parent;
            CurDisc.position = temp;
            this.transform.parent=Parent;

        }
        
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        this.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.transform.GetChild(0).gameObject.SetActive(false);
    }
   
}
