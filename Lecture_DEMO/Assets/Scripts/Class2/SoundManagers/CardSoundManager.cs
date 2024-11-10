using System.Collections.Generic;
using Class1.PlantsChooser;
using UnityEngine;

namespace Class2.SoundManagers
{
    public class CardSoundManager : MonoBehaviour
    {
        private List<CardControl> _cards;
        private AudioSource _plantSound;
        private AudioSource _lackOfSunSound;
        private AudioSource _pickUpSound;
        private AudioSource _putBackSound;
        void Start()
        {
            //初始化卡牌列表
            //初始化音效
        }

        public void PlayPlantSound()
        {
            _plantSound.Play();
        }
        public void PlayLackOfSunSound()
        {
            _lackOfSunSound.Play();
        }
        public void PlayPickUpSound()
        {
            _pickUpSound.Play();
        }
        public void PlayPutBackSound()
        {
            _putBackSound.Play();
        }
    }
}
