using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class PlantTracer : MonoBehaviour
{
    private static GameObject _bindingPlant;
    public static SpriteRenderer SpriteRenderer;
    public static bool IsTracing;
    private static Dictionary<string, string> _capitalizedPlantName;

    private void OnEnable()
    {
        _bindingPlant = transform.GetChild(0).gameObject;
        SpriteRenderer = _bindingPlant.GetComponent<SpriteRenderer>();
        //初始化音效管理器
        InitializeAllCapitalizedPlantName();
    }

    private void InitializeAllCapitalizedPlantName()
    {
        _capitalizedPlantName = new Dictionary<string, string>();
        _capitalizedPlantName.Add("peashooter", "Peashooter");
        _capitalizedPlantName.Add("jalapeno", "Jalapeno");
        _capitalizedPlantName.Add("potatomine", "PotatoMine");
        _capitalizedPlantName.Add("snowpea", "SnowPea");
        _capitalizedPlantName.Add("squash", "Squash");
        _capitalizedPlantName.Add("sunflower", "Sunflower");
        _capitalizedPlantName.Add("wallnut", "WallNut");
    }
    
    //测试用重载
    // public void StartTracing()
    // {
    //     _bindingPlant.SetActive(true);
    //     _isTracing = true;
    // }
    public static void StartTracing(PlantCardConfig cardConfig)
    {
        string path = "Images/Plants/"+ _capitalizedPlantName[cardConfig.Name] +"/"+_capitalizedPlantName[cardConfig.Name]+ "_1";
        SpriteRenderer.sprite = Resources.Load<Sprite>(path);
        _bindingPlant.SetActive(true);
        IsTracing = true;
    }
    
    public static void StopTracing()
    {
        IsTracing = false;
        _bindingPlant.SetActive(false);
        //声音播放
        //todo...
    }
    private void Update()
    {
        if(!IsTracing)return;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        _bindingPlant.transform.position = ray.origin;
    }
    
}
