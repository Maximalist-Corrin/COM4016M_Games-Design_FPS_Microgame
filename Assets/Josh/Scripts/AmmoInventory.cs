using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;



namespace Josh.Scripts
{
    public class AmmoInventory : MonoBehaviour
    {
        public SerializedDictionary<AmmoType, float> StoredAmmo = new SerializedDictionary<AmmoType, float>();
        public bool IsInfiniteAmmo = false;
        public bool HasAmmo(AmmoType ammoType)
        {
            if (IsInfiniteAmmo) return true;
            return StoredAmmo.TryGetValue(ammoType, out float ammo) && ammo > 0;
        }
    
        public float GetAmmo(AmmoType ammoType, float amount)
        {
            if (IsInfiniteAmmo) return amount;
            
            StoredAmmo.TryGetValue(ammoType, out float ammo);
            if (ammo >= amount)
            {
                StoredAmmo[ammoType] -= amount;
                return amount;
            }
            
            float ammoToReturn = ammo;
            StoredAmmo[ammoType] = 0;
            return ammoToReturn;
        }

        public void AddAmmo(AmmoType ammoType, float amount)
        {
            if (IsInfiniteAmmo) return;
                
            if (StoredAmmo.ContainsKey(ammoType))
            {
                StoredAmmo[ammoType] += amount;
            }
        }
    }
}