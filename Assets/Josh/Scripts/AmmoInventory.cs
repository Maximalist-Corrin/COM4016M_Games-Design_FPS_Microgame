using System;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using Unity.FPS.Game;
using UnityEngine;
using UnityEngine.Events;


namespace Josh.Scripts
{
    public class AmmoInventory : MonoBehaviour
    {
        public SerializedDictionary<AmmoType, float> StoredAmmo = new SerializedDictionary<AmmoType, float>();
        public bool IsInfiniteAmmo = false;
        
        public UnityAction<AmmoType, float> OnAmmoChange;
        public bool HasAmmo(AmmoType ammoType)
        {
            if (IsInfiniteAmmo) return true;
            return StoredAmmo.TryGetValue(ammoType, out float ammo) && ammo > 0;
        }
    
        public float GetAmmo(AmmoType ammoType, float amount)
        {
            if (IsInfiniteAmmo) return amount;
            
            float currentAmmo = StoredAmmo.GetValueOrDefault(ammoType, 0);
            
            float ammoToReturn = Mathf.Min(currentAmmo, amount);
            StoredAmmo[ammoType] = currentAmmo - ammoToReturn;
            
            UpdateStoredAmmoEvent evt = Events.UpdateStoredAmmoEvent;
            evt.AmmoType = ammoType;
            evt.AmmoCount = StoredAmmo[ammoType];
            EventManager.Broadcast(evt);

            return ammoToReturn;

        }

        public void AddAmmo(AmmoType ammoType, float amount)
        {
            if (IsInfiniteAmmo) return;
                
            if (StoredAmmo.ContainsKey(ammoType))
            {
                StoredAmmo[ammoType] += amount;
                UpdateStoredAmmoEvent evt = Events.UpdateStoredAmmoEvent;
                evt.AmmoType = ammoType;
                evt.AmmoCount = amount;
                EventManager.Broadcast(evt);
            }
        }
    }
}