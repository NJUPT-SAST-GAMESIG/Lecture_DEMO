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
    
    private ISunManager _sunManager; //这几个管理器的初始化是权宜之计，后面会再改
    private CardSoundManager _cardSoundManager; //
    private PlantTracer _plantTracer;//
    
    private void OnEnable()
    {
        _cardImage = GetComponent<Image>();
        _cardSlider = GetComponentInChildren<Slider>();
    }
    

    private void Update()
    {
        UpdateCooldown();
        UpdateCover();
    }

    private void UpdateCover()
    {
        if (_isCd) return;
        // if (_sunManager.GetSunValue() < _card.SunShineReduce)
        // {
        //     string path = Path.Combine("Images/Card", _card.Name + "2");
        //     Sprite sprite = Resources.Load<Sprite>(path);
        //     _cardImage.sprite = sprite;
        // }
        // else
        // {
        //     string path = Path.Combine("Images/Card", _card.Name);
        //     Sprite sprite = Resources.Load<Sprite>(path);
        //     _cardImage.sprite = sprite;
        // }
    }
    
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

    public void SetSunManager(ISunManager sunManager)
    {
        _sunManager = sunManager;
    }
    public void SetCardSoundManager(CardSoundManager cardSoundManager)
    {
        _cardSoundManager = cardSoundManager;
    }
    public void SetPlantTracer(PlantTracer plantTracer)
    {
        _plantTracer = plantTracer;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (_isCd)
            return;
        if (_sunManager.GetSunValue() < _cardConfig.SunShineReduce)
        {
            //播放音效
            CardSoundManager.Play(CardSoundType.LackOfSunSound);
            return;
        }
        //开始植物追踪
        _plantTracer.StartTracing(_cardConfig);
        CardSoundManager.Play(CardSoundType.PickUpSound);
        
        var path = "Images/Card/card_"+ _cardConfig.Name + "2";
        var sprite = Resources.Load<Sprite>(path);
        _cardImage.sprite = sprite;
        _cdStartTime = Time.time;
        _isCd = true;
    }
}