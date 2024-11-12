using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridScript : MonoBehaviour,IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler
{
    private GridManager _gridManager;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetGridController(GridManager gridManager)
    {
        _gridManager = gridManager;
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
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
