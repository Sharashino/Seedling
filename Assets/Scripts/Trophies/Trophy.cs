using Seedling.Enums;
using UnityEngine;

namespace Seedling.SO
{
    [CreateAssetMenu(fileName = "New Trophy", menuName = "Trophy")]
    public class Trophy : ScriptableObject
    {
        public string trophyName;
        public string trophyDesc;
        public Sprite trophyImage; 
        public TrophyType trophyType;
    }
}