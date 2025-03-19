using UnityEngine;

namespace Josh.Scripts
{
    public class Magazine : MonoBehaviour
    {
        public MagazineData UsedMagazineData;
        public float CurrentAmmo;

        void Start()
        {
            CurrentAmmo = UsedMagazineData.MagazineSize;
        }

        public void FullLoad()
        {
            CurrentAmmo = UsedMagazineData.MagazineSize;
        }

        public void ReduceAmmo(float amount)
        {
            CurrentAmmo = Mathf.Clamp(CurrentAmmo - amount, 0, UsedMagazineData.MagazineSize);

        }
        public float AmmoNeededToFill()
        {
            return UsedMagazineData.MagazineSize - CurrentAmmo;
        }

        public float LoadMagazine(float amount)
        {
            float totalLoad = CurrentAmmo + amount;
            if (totalLoad > UsedMagazineData.MagazineSize)
            {
                float overflow = totalLoad - UsedMagazineData.MagazineSize;
                CurrentAmmo = UsedMagazineData.MagazineSize;
                return overflow;
            }
            CurrentAmmo = totalLoad;
            return 0;
        }

        public float CurrentAmmoRatio()
        {
            return CurrentAmmo / UsedMagazineData.MagazineSize;
        }

        public bool HasAmmo()
        {
            return CurrentAmmo > 0;
        }

        public bool IsFull()
        {
            return CurrentAmmo >= UsedMagazineData.MagazineSize;
        }
    }
}
