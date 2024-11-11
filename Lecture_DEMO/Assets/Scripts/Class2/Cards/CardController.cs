using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    private GameObject _plantCardPanel;
    private List<PlantCard> _cards;

    private void Start()
    {
        _plantCardPanel = GameObject.Find("Canvas/PlantsChooser/CardPanel");
        LoadCard(new PlantCardConfig(0, "card_peashooter", 100, 1));
        LoadCard(new PlantCardConfig(1, "card_cherrybomb", 150, 5));
    }

    public void AddCard(int id, string name, int sunShineReduce, int cdTime)
    {
        var plantCard = new PlantCard();
        _cards.Add(plantCard);
    }

    // Update is called once per frame
    private void LoadCard(PlantCardConfig plantCardConfig)
    {
        var plantCardPre = Resources.Load<GameObject>("PlantsCardPrefab/PlantCard");
        var plantCardObject = Instantiate(plantCardPre, _plantCardPanel.transform);
        plantCardObject.GetComponent<PlantCard>().SetCard(plantCardConfig);
        var plantCardImage = plantCardObject.GetComponent<Image>();
        var path = Path.Combine("Images/Card", plantCardConfig.Name);
        plantCardImage.sprite = Resources.Load<Sprite>(path);
    }
}