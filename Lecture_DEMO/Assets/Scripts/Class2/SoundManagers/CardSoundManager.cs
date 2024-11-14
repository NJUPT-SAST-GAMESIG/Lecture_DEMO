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
    private static AudioSource plantSound;
    private static AudioSource lackOfSunSound;
    private static AudioSource pickUpSound;
    private static AudioSource putBackSound;
    public const string PlantSoundPath = "Audio/Sound/";

    private void Start()
    {
        plantSound = gameObject.AddComponent<AudioSource>();
        plantSound.playOnAwake = false;
        plantSound.clip = Resources.Load<AudioClip>(PlantSoundPath + "plant");
        
        lackOfSunSound = gameObject.AddComponent<AudioSource>();
        lackOfSunSound.playOnAwake = false;
        
        pickUpSound = gameObject.AddComponent<AudioSource>();
        pickUpSound.playOnAwake = false;
        pickUpSound.clip = Resources.Load<AudioClip>(PlantSoundPath + "pause");
        
        putBackSound = gameObject.AddComponent<AudioSource>();
        putBackSound.playOnAwake = false;
        
    }

    public static void Play(CardSoundType cardSoundType)
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