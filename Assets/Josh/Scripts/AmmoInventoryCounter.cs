using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.FPS.Game;

namespace Josh.Scripts
{
    public class AmmoInventoryCounter : MonoBehaviour
    {
        [Tooltip("Text for Bullet Counter")] 
        public TextMeshProUGUI BulletCounter;
        
        [Tooltip("Text for Bullet Name")] 
        public TextMeshProUGUI BulletName;
    
        [Tooltip("Image for the Bullet icon")] 
        public Image BulletImage;
    
        private int m_Bullets;
        
        private AmmoType m_AmmoType;

        private void Awake()
        {
            EventManager.AddListener<UpdateStoredAmmoEvent>(OnAmmoChanged);
        }

        void OnAmmoChanged(UpdateStoredAmmoEvent evt)
        {
            Debug.Log("Ammo Inventory Counter Updated");
            if (evt.AmmoType == m_AmmoType)
            {
                UpdateAmmo(evt.AmmoCount);
            }
        }
        public void Initialize(AmmoType magazineData, float bullets)
        {
            Debug.Log("Ammo Inventory Counter Initialized");
            m_AmmoType = magazineData;
            BulletName.text = m_AmmoType.Name;
            UpdateAmmo(bullets);
        }
        public void UpdateAmmo(float ammo)
        {
            m_Bullets = (int)ammo;
            BulletCounter.text = m_Bullets.ToString();
        }
    }
}
