using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public enum CardSoundType
{
    PlantSound,
    LackOfSunSound,
    PickUpSound,
    PutBackSound
}
public class CardSoundManager : MonoBehaviour
{
    private List<PlantCard> _cards;
    [SerializeField]private AudioSource plantSound;
    [SerializeField]private AudioSource lackOfSunSound;
    [SerializeField]private AudioSource pickUpSound;
    [SerializeField]private AudioSource putBackSound;

    private void Start()
    {
        //初始化卡牌列表
        //初始化音效
    }

    public void Play(CardSoundType cardSoundType)
    {
        switch (cardSoundType)
        {
            case CardSoundType.PlantSound:
                plantSound.Play();
                break;
            case CardSoundType.PickUpSound:
                pickUpSound.Play();
                break;
            case CardSoundType.PutBackSound:
                putBackSound.Play();
                break;
            case CardSoundType.LackOfSunSound:
                lackOfSunSound.Play();
                break;
            default: print("没有这个音效类型"); break;
        }
    }
}