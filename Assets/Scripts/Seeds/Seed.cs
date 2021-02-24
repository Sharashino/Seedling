using UnityEngine;
using Seedling.Enums;

namespace Seedling.SO
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item/Seeds")]
    public class Seed : ScriptableObject
    {
        public Sprite seedIcon;
        public string seedName = "New Seed";
        public string seedDesc = "Seed desc";
        public GameObject seedObject;
        public SeedlingType seedlingType;
        public int coinsToUnlock;
        public int harvestCoins;
        public int minutesToGrow;
        public bool isUnlocked = false;
        public bool isDoneGrowing = false;
        public string seedlingCuriosity;
    }
}
