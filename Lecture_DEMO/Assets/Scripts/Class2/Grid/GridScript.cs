using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GridScript : MonoBehaviour,IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler
{
    private GridManager _gridManager;
    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    public void SetGridController(GridManager gridManager)
    {
        _gridManager = gridManager;
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        print("PointerClick");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _gridManager.SetIsPointerEnter(true);
        print("PointerEnter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _gridManager.SetIsPointerEnter(false);
        print("PointerExit");
    }
}
