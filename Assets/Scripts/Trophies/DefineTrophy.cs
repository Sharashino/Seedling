using UnityEngine;

public class DefineTrophy : MonoBehaviour
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
