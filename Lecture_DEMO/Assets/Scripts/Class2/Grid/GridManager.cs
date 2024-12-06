using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager
{
    private List<GridScript> _grids;
    private List<GameObject> _gridObjects;
    public static bool IsPointerEnter;
    public static PlantCard Card;
    private static Transform _gridsTransform;
    private static GridManager _instance;
    public static GridManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GridManager();
            }
            return _instance;
        }
    }
    //禁用外部无参构造
    private GridManager()
    {
        _gridObjects = new List<GameObject>();
        _grids = new List<GridScript>();
        //疑似高性能消耗，可能会卡顿
        for (int i = 0; i < 45; i++)
        {
            _gridObjects.Add(GameObject.Find("Canvas/Grids").transform.GetChild(i).gameObject);
            _gridObjects[i].AddComponent<GridScript>();
            _grids.Add(_gridObjects[i].GetComponent<GridScript>());
        }
    }
    public static void ReduceSunNum()
    {
        SunManager.SunReduce(Card.GetCardCost());
    }
}
