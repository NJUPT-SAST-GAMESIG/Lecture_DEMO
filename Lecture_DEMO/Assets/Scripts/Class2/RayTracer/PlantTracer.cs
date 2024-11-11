using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
    public void StartTracing(PlantCardConfig cardConfig)
    {
        _bindingPlant.SetActive(true);
        string path = Path.Combine("Images/Plants/", cardConfig.Name + "_1");
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
        _bindingPlant.transform.position = ray.origin;
    }
}
