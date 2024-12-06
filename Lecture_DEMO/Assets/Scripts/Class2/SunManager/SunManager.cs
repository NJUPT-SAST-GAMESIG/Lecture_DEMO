using System;
using UnityEngine;

public class SunManager
{
    private static SunManager _instance;
    public static SunManager Instance { get; } = new SunManager();
    private static int SunNum{get;set;}
    public static void SunReduce(int sunCost)
    {
        SunNum -= sunCost;
    }

    public void SunIncrease()
    {
        SunNum += 25;
    }

    public static int GetSunValue()
    {
        int sunValue = SunNum;
        return sunValue;
    }
    
    private void Start()
    {
        SunNum = 100;
    }
}