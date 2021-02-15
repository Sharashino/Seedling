using UnityEngine;

public class DefineTrophy : MonoBehaviour
{
    [SerializeField] private Trophy trophy;
   
    public Trophy TrophyObject
    {
        get
        {
            return trophy;
        }
    }
}
