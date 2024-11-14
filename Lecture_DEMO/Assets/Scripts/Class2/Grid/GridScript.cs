using Class2.RayTracer;
using Class2.SoundManagers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Class2.Grid
{
    public class GridScript : MonoBehaviour,IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler
    {
        private GridManager _gridManager;
        private Image _image;
        private bool _isPlanted;

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
            if(_isPlanted) return;
            if (!PlantTracer.IsTracing) return;
            _isPlanted = true;
            _image.sprite = _gridManager.GetSpriteOnPlantTracer();
            _image.color = new Color(255, 255, 255, 1f);//植物成功种植，后面改成动画
            CardSoundManager.Play(CardSoundType.PlantSound);
            PlantTracer.StopTracing();
            GridManager.card.SetCardInCd();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (_isPlanted) return;
            if (!PlantTracer.IsTracing) return;
            _gridManager.SetIsPointerEnter(true);
            _image.sprite = _gridManager.GetSpriteOnPlantTracer();
            _image.color = new Color(255,255,255,0.7f);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (_isPlanted) return;
            if(!PlantTracer.IsTracing) return;
            _gridManager.SetIsPointerEnter(false);
            _image.color = new Color(255,255,255,0f);
            _image.sprite = null;
        }

    
    }
}
