using System.Collections.Generic;
using UnityEngine;

public class AmmoInventory : MonoBehaviour
{
    public Dictionary<AmmoType, int> StoredAmmo = new Dictionary<AmmoType, int>();

    public bool HasAmmo(AmmoType ammoType)
    {
        return StoredAmmo.TryGetValue(ammoType, out int ammo) && ammo > 0;
    }
    
    public int GetAmmo(AmmoType ammoType, int amount)
    {
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
        if (StoredAmmo.ContainsKey(ammoType))
        {
            StoredAmmo[ammoType] += amount;
        }
    }
}