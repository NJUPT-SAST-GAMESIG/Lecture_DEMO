using System;
using UnityEngine;

public class SunManager : MonoBehaviour,ISunManager
{
    private int SunNum{get;set;}
    public void SunReduce(int sunCost)
    {
        SunNum -= sunCost;
    }
    
    public int GetSunValue()
    {
        int sunValue = SunNum;
        return sunValue;
    }

    public bool SunNumJudge()
    {
        return true;
    }
}