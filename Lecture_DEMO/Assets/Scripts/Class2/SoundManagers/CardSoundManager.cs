using System.Collections.Generic;
using UnityEngine;

public class CardSoundManager : MonoBehaviour
{
    private List<PlantCard> _cards;
    private AudioSource _plantSound;
    private AudioSource _lackOfSunSound;
    private AudioSource _pickUpSound;
    private AudioSource _putBackSound;

    private void Start()
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