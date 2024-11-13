using Class2.Grid;
using Class2.RayTracer;
using Class2.SoundManagers;
using Class2.SunManager;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Class2.Cards
{
    public class PlantCard : MonoBehaviour, IPointerClickHandler
    {
        private static PlantCardConfig _cardConfig;

        public static bool IsCd;

        public static float CdStartTime;

        private static Image _cardImage;
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
            if (IsCd) return;
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
            if (!IsCd)
                return;
            _cardSlider.value = 1 - (Time.time - CdStartTime) / _cardConfig.CardCd;
            if (Time.time > CdStartTime + _cardConfig.CardCd)
            {
                var path = "Images/Card/card_"+ _cardConfig.Name;
                var sprite = Resources.Load<Sprite>(path);
                _cardImage.sprite = sprite;
                IsCd = false;
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
            if (PlantTracer.IsTracing)
            {
                return;
            }
            if (IsCd)
                return;
            if (_sunManager.GetSunValue() < _cardConfig.SunShineReduce)
            {
                //播放音效
                CardSoundManager.Play(CardSoundType.LackOfSunSound);
                return;
            }
            //开始植物追踪
            _plantTracer.StartTracing(_cardConfig);
            GridManager.card = this;
            CardSoundManager.Play(CardSoundType.PickUpSound);
        
            //SetCardInCd();
        }

        public void SetCardInCd()
        {
            var path = "Images/Card/card_"+ _cardConfig.Name + "2";
            var sprite = Resources.Load<Sprite>(path);
            _cardImage.sprite = sprite;
            CdStartTime = Time.time;
            IsCd = true;
        }
    }
}