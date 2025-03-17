using UnityEngine;
using UnityEngine.Serialization;

public enum AmmoType
{
    Bullet,
    Shell
}

[CreateAssetMenu(fileName = "NewMagazineData", menuName = "Josh/Magazine Data")]
public class MagazineData : ScriptableObject
{
    public AmmoType UsedAmmoType;
    public int MagazineSize;
}