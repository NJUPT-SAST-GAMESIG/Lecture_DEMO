using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Class1.PlantsChooser;
using Class2.SoundManagers;
using Unity.VisualScripting;
using UnityEngine;

public class PlantTracer : MonoBehaviour
{
    private GameObject _bindingPlant;
    private Sprite _sprite;
    private bool _isTracing;
    private CardSoundManager _cardSoundManager;

    private void Start()
    {
        _bindingPlant = transform.GetChild(0).gameObject;
        _sprite = _bindingPlant.GetComponent<Sprite>();
        //初始化音效管理器
    }
    
    //测试用重载
    public void StartTracing()
    {
        _bindingPlant.SetActive(true);
        _isTracing = true;    
    }
    public void StartTracing(PlantCard card)
    {
        _bindingPlant.SetActive(true);
        string path = Path.Combine("Images/Card", card.Name + "2");//这个路径是有问题的，记得改
        _sprite = Resources.Load<Sprite>(path);
        _isTracing = true;
    }
    
    public void StopTracing()
    {
        _isTracing = false;
        _bindingPlant.SetActive(false);
        //声音播放
        //todo...
    }
    private void Update()
    {
        if(!_isTracing)return;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // if (Physics.Raycast(ray, out var hit))
        // {
        //     transform.position = hit.point;
        // }
        _bindingPlant.transform.position = ray.origin;
    }
}
