using System;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlantCard : MonoBehaviour, IPointerClickHandler
{
    private PlantCardConfig _cardConfig;

    private bool _isCd;

    private float _cdStartTime;

    private Image _cardImage;
    private Slider _cardSlider;
    
    private void OnEnable()
    {
        _cardImage = GetComponent<Image>();
        _cardSlider = GetComponentInChildren<Slider>();
    }
    

    private void Update()
    {
        UpdateCooldown();
        // UpdateCover();
    }

    // private void UpdateCover()
    // {
    //     if (IsCd) return;
    //     // if (_sunManager.GetSunValue() < _card.SunShineReduce)
    //     // {
    //     //     string path = Path.Combine("Images/Card", _card.Name + "2");
    //     //     Sprite sprite = Resources.Load<Sprite>(path);
    //     //     _cardImage.sprite = sprite;
    //     // }
    //     // else
    //     // {
    //     //     string path = Path.Combine("Images/Card", _card.Name);
    //     //     Sprite sprite = Resources.Load<Sprite>(path);
    //     //     _cardImage.sprite = sprite;
    //     // }
    // }
    
    private void UpdateCooldown()
    {
        if (!_isCd)
            return;
        _cardSlider.value = 1 - (Time.time - _cdStartTime) / _cardConfig.CardCd;
        if (Time.time > _cdStartTime + _cardConfig.CardCd)
        {
            var path = "Images/Card/card_"+ _cardConfig.Name;
            var sprite = Resources.Load<Sprite>(path);
            _cardImage.sprite = sprite;
            _isCd = false;
        }
    }

    public void SetCard(PlantCardConfig cardConfig)
    {
        _cardConfig = cardConfig;
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (PlantTracer.IsTracing)
        {
            return;
        }
        if (_isCd)
            return;
        if (SunManager.GetSunValue() < _cardConfig.SunShineReduce)
        {
            //播放音效
            CardSoundManager.Play(CardSoundType.LackOfSunSound);
            return;
        }
        //开始植物追踪
        PlantTracer.StartTracing(_cardConfig);
        CardSoundManager.Play(CardSoundType.PickUpSound);
        GridManager.Card = this;
    }

    public void StartCoolingdown()
    {
        var path = "Images/Card/card_"+ _cardConfig.Name + "2";
        var sprite = Resources.Load<Sprite>(path);
        _cardImage.sprite = sprite;
        _cdStartTime = Time.time;
        _isCd = true;
    }

    public int GetCardCost()
    {
        return _cardConfig.SunShineReduce;
    }

    public string GetName()
    {
        return _cardConfig.Name; 
    }
}