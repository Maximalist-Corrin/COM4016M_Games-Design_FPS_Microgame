using UnityEngine;
using UnityEngine.UI;

namespace Josh.Scripts
{
    [CreateAssetMenu(fileName = "Ammo Type", menuName = "Josh/Ammo Type")]
    public class AmmoType : ScriptableObject
    {
        public string Name;
        public Image Icon;
    }
}
