using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameApp : MonoBehaviour
{
    private CardManager _cardManager;
    private GridManager _gridManager;
    void Start()
    {
        _cardManager = CardManager.Instance;
        _gridManager = GridManager.Instance;
    }

    void Update()
    {
        
    }
}
