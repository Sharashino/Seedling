using Seedling.Seeds;
using Seedling.SO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Seedling.Managers
{
    public class SaveManager : MonoBehaviour
    {
        #region Singleton

        private static SaveManager _instance = null;
        public static SaveManager Instance
        {
            get
            {
                if (_instance == null) Debug.LogError("[SaveManager-Static] No Save Manager on the scene!");
                return _instance;
            }
            private set => _instance = value;
        }

        #endregion

        private void Awake()
        {
            if (!_instance)
            {
                _instance = this;
            }
        }


        public void SaveSeedData(Seed seed, int growTime)
        {

        }

        public void SaveData()
        {

        }
    }
}
