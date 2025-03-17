using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magazine : MonoBehaviour
{
    public MagazineData UsedMagazineData;
    public int CurrentAmmo;

    public void ReduceAmmo(int amount)
    {
        CurrentAmmo -= amount;
    }

    public int LoadMagazine(int amount)
    {
        int totalLoad = CurrentAmmo + amount;
        if (totalLoad > UsedMagazineData.MagazineSize)
        {
            int overflow = totalLoad - UsedMagazineData.MagazineSize;
            CurrentAmmo = UsedMagazineData.MagazineSize;
            return overflow;
        }
        CurrentAmmo = totalLoad;
        return 0;
    }

    public bool HasAmmo()
    {
        return CurrentAmmo > 0;
    }

    public bool IsFull()
    {
        return CurrentAmmo == UsedMagazineData.MagazineSize;
    }
}
