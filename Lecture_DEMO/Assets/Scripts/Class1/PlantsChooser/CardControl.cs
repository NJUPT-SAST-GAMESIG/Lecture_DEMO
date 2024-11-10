using System;
using System.IO;
using Class2.SunManager;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Class1.PlantsChooser
{
    public class CardControl : MonoBehaviour, IPointerClickHandler
    {
        private PlantCard _card;

        private bool _isCd;

        private float _cdStartTime;

        private Image _cardImage;
        private Slider _cardSlider;
        private Image _cover;//冷却遮罩
        private ISunManager _sunManager;//获取阳光管理器的引用,记得想办法初始化

        private void OnEnable()
        {
            _cardImage = GetComponent<Image>();
            _cardSlider = GetComponentInChildren<Slider>();
            _cover = GetComponentInChildren<Image>();
            //初始化阳光管理器
        }

        // Start is called before the first frame update
        private void Start()
        {
           
        }

        // Update is called once per frame
        void Update()
        {
            UpdateCooldown();
            if (_isCd) return;
            if (_sunManager.GetSunValue() < _card.SunShineReduce)
            {
                _cover.color = new Color(142,142,142,224);
            }
        }

        private void UpdateCooldown()
        {
            if (!_isCd)
                return;
            _cardSlider.value = 1 - (Time.time - _cdStartTime) / _card.CardCd;
            if (Time.time > _cdStartTime + _card.CardCd)
            {
                string path = Path.Combine("Images/Card", _card.Name);
                Sprite sprite = Resources.Load<Sprite>(path);
                _cardImage.sprite = sprite;
                _isCd = false;
            }
        }

        public void SetCard(PlantCard card)
        {
            this._card = card;
        }


        public void OnPointerClick(PointerEventData eventData)
        {
            if (_isCd)
                return;
            string path = Path.Combine("Images/Card", _card.Name + "2");
            Sprite sprite = Resources.Load<Sprite>(path);
            _cardImage.sprite = sprite;
            _cdStartTime = Time.time;
            _isCd = true;
        }
    }
}