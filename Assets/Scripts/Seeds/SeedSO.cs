using Seedling.Enums;
using Seedling.Seeds;
using UnityEngine;

namespace Seedling.SO
{
    [CreateAssetMenu(fileName = "New Seed", menuName = "Seeds/New Seed")]
    public class SeedSO : ScriptableObject
    {
        public Sprite seedIcon;
        public string seedName = "New Seed";
        public string seedDesc = "Seed desc";
        public string seedCuriosity;
        public Seed seedObject;
        public Flower flowerObject;
        public SeedType seedType;
        public int coinsToUnlock;
        public int coinsForPlanting;
        public int growTime;
        public bool isUnlocked = false;
    }
}
