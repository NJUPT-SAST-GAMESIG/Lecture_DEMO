using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GridScript : MonoBehaviour,IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler
{
    private Image _image;
    private bool _isPlanted;

    private void Start()
    {
        _image = GetComponent<Image>();
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if(_isPlanted) return;
        if (!PlantTracer.IsTracing) return;
        GridManager.Card.StartCoolingdown();
        GridManager.ReduceSunNum();
        _isPlanted = true;
        _image.sprite = PlantTracer.SpriteRenderer.sprite;
        _image.color = new Color(255, 255, 255, 1f);//植物成功种植，后面改成动画
        CardSoundManager.Play(CardSoundType.PlantSound);
        PlantTracer.StopTracing();

        //Debug.Log(_gridManager.card.GetName());
        string cardName = GridManager.Card.GetName();
        
        
        UnityEngineInternal.APIUpdaterRuntimeServices.AddComponent(gameObject, "Assets/Scripts/Class2/Grid/GridScript.cs (39,9)", cardName);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_isPlanted) return;
        if (!PlantTracer.IsTracing) return;
        GridManager.IsPointerEnter = true;
        _image.sprite = PlantTracer.SpriteRenderer.sprite;
        _image.color = new Color(255,255,255,0.7f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_isPlanted) return;
        if(!PlantTracer.IsTracing) return;
        GridManager.IsPointerEnter = false;
        _image.color = new Color(255,255,255,0f);
        _image.sprite = null;
    }

    public void ReleaseGrid()//用于在植物被销毁后的地块可种植
    {
        _isPlanted = false;
    }  
}
