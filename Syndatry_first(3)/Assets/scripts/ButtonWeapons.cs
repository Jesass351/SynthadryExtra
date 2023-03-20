using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ButtonWeapons : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public bool a = false;
    Button button;
    private void Start()
    {
        button = GetComponent<Button>();
        button.interactable = false;
        button.image.enabled = false;
        
    }
    public void ChangeA()
    {
        a = true;
        
    }
    

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
    }


    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
    }
}
