using TMPro;
using UnityEngine;

namespace Class1.PlantsChooser
{
    public class SunShineCounter : MonoBehaviour
    {
        private TextMeshProUGUI _text;
        private int _sunShineNum = 200;
        private void Start()
        {
            _text = GetComponent<TextMeshProUGUI>();
            FreshText();
        }

        public void AddSunShine(int num)
        {
            _sunShineNum += num;
            FreshText();
        }

        public bool UseSunShine(int num)
        {
            int temp = _sunShineNum - num;
            if(temp < 0)
                return false;
            _sunShineNum = temp;
            FreshText();
            return true;
        }

        public void FreshText()
        {
            _text.text = _sunShineNum.ToString();
        }
    }
}
