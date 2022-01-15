using Seedling.Enums;
using UnityEngine;

namespace Seedling.SO
{
    [CreateAssetMenu(fileName = "New Seed", menuName = "Inventory/Item/Seeds")]
    public class Seed : ScriptableObject
    {
        public Sprite seedIcon;
        public string seedName = "New Seed";
        public string seedDesc = "Seed desc";
        public string seedCuriosity;
        public GameObject seedObject;
        public SeedType seedType;
        public int coinsToUnlock;
        public int coinsForPlanting;
        public int growTime;
        public bool isUnlocked = false;
    }
}
