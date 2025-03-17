using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;



namespace Josh.Scripts
{
    public class AmmoInventory : MonoBehaviour
    {
        public SerializedDictionary<AmmoType, int> StoredAmmo = new SerializedDictionary<AmmoType, int>();
        public bool IsInfiniteAmmo = false;
        public bool HasAmmo(AmmoType ammoType)
        {
            if (IsInfiniteAmmo) return true;
            return StoredAmmo.TryGetValue(ammoType, out int ammo) && ammo > 0;
        }
    
        public int GetAmmo(AmmoType ammoType, int amount)
        {
            if (IsInfiniteAmmo) return amount;
            
            StoredAmmo.TryGetValue(ammoType, out int ammo);
            if (ammo >= amount)
            {
                StoredAmmo[ammoType] -= amount;
                return amount;
            }
            
            int ammoToReturn = ammo;
            StoredAmmo[ammoType] = 0;
            return ammoToReturn;
        }

        public void AddAmmo(AmmoType ammoType, int amount)
        {
            if (IsInfiniteAmmo) return;
                
            if (StoredAmmo.ContainsKey(ammoType))
            {
                StoredAmmo[ammoType] += amount;
            }
        }
    }
}