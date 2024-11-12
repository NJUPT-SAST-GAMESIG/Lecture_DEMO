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
    private GameObject _cover; //冷却遮罩
    private ISunManager _sunManager; //获取阳光管理器的引用,记得想办法初始化
    private CardSoundManager _cardSoundManager; //获取音效管理器的引用,记得想办法初始化

    private void OnEnable()
    {
        _cardImage = GetComponent<Image>();
        _cardSlider = GetComponentInChildren<Slider>();
        //初始化阳光管理器
        //初始化音效管理器
    }

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
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
            var path = Path.Combine("Images/Card", _cardConfig.Name);
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
        if (_isCd)
            return;
        // if (_sunManager.GetSunValue() < _card.SunShineReduce)
        // {
        //     //播放音效
        //     _cardSoundManager.PlayLackOfSunSound();
        //     return;
        // }
        var path = Path.Combine("Images/Card", _cardConfig.Name + "2");
        var sprite = Resources.Load<Sprite>(path);
        _cardImage.sprite = sprite;
        _cdStartTime = Time.time;
        _isCd = true;
    }
}