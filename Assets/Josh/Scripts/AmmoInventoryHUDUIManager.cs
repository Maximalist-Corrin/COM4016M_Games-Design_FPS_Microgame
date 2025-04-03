using System.Collections.Generic;
using Unity.FPS.Game;
using UnityEngine;

namespace Josh.Scripts
{
    public class AmmoInventoryHUDUIManager : MonoBehaviour
    {
        private AmmoInventory m_AmmoInventory;
        List<AmmoInventoryCounter> m_AmmoInventoryCounters = new List<AmmoInventoryCounter>();
        
        public GameObject AmmoInventoryCounterPrefab;

        public RectTransform OwnerPanel;
        
        void Start()
        {
            m_AmmoInventory = FindObjectOfType<AmmoInventory>();
            DebugUtility.HandleErrorIfNullFindObject<AmmoInventory, AmmoInventoryHUDUIManager>(m_AmmoInventory,
                this);
            
            if (AmmoInventoryCounterPrefab == null)
                return;
            
            foreach (var ammo in m_AmmoInventory.StoredAmmo)
            {
                Debug.Log(ammo.Key + " " + ammo.Value);
                if (ammo.Value > 0)
                {
                    GameObject counter = Instantiate(AmmoInventoryCounterPrefab, OwnerPanel);
                    AmmoInventoryCounter newAmmoInventoryCounter = counter.GetComponent<AmmoInventoryCounter>();
                    DebugUtility.HandleErrorIfNullGetComponent<AmmoInventoryCounter, AmmoInventoryHUDUIManager>(newAmmoInventoryCounter, this,
                        counter.gameObject);
                    
                    newAmmoInventoryCounter.Initialize(ammo.Key, ammo.Value);
                    m_AmmoInventoryCounters.Add(newAmmoInventoryCounter);
                }
            }
        }

        void Update()
        {
        
        }
    }
}
