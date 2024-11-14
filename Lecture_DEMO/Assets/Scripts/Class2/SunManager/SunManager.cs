using UnityEngine;

namespace Class2.SunManager
{
    public class SunManager : MonoBehaviour,ISunManager
    {
        private int SunNum{get;set;}
        private int NormalSunNum{get;set;}
        public void SunReduce(int sunCost)
        {
            SunNum -= sunCost;
        }

        private void Start()
        {
            SunNum = 0;
            NormalSunNum = 25;
        }

        public int GetSunValue()
        {
            int sunValue = SunNum;
            return sunValue;
        }

        public void SunIncrease()
        {
            SunNum += NormalSunNum;
        }
    }
}