using UnityEngine;

[CreateAssetMenu(fileName = "New Trophy", menuName = "Trophy")]
public class Trophy : ScriptableObject
{
    public string trophyName;
    public string trophyDesc;
    public TrophyType trophyType;
}

public enum TrophyType
{
    Richart,
    Seedler,
    Supporter,
    IndianaJohnes
}
