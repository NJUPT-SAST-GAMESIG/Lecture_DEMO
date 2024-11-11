public class PlantCardConfig
{
    public int Id;
    public string Name;
    public int SunShineReduce;
    public float CardCd;

    public PlantCardConfig(int id, string name, int sunShineReduce, float cardCd)
    {
        Id = id;
        Name = name;
        SunShineReduce = sunShineReduce;
        CardCd = cardCd;
    }
}