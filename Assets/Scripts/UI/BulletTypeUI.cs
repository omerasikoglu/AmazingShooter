using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class BulletTypeUI : MonoBehaviour
{
    //events
    public event EventHandler<OnBulletTypeChangedEventArgs> OnBulletTypeChanged;
    public event EventHandler<OnBulletCountChangedEventArgs> OnBulletCountChanged;
    public event EventHandler OnExplosionChanged;
    public class OnBulletTypeChangedEventArgs : EventArgs
    {
        public bool isShotgunBullet;
    }
    public class OnBulletCountChangedEventArgs : EventArgs
    {
        public float bulletCount;
    }

    //transforms
    [SerializeField] private Transform gun;
    [SerializeField] private Transform shotgun;
    [SerializeField] private Transform explosion;
    [SerializeField] private Transform shotgunAmmo;
    private void Start()
    {
        /*
         * 1.GunButton | 2.ShotgunButton | 3.ExplosionButton | 4.ShotgunAmmoSlider
         */

        gun.GetComponent<Button>().onClick.AddListener(() =>
            {
                OnBulletTypeChanged?.Invoke(this, new OnBulletTypeChangedEventArgs
                { isShotgunBullet = false });
            });

        shotgun.GetComponent<Button>().onClick.AddListener(() =>
        {
            OnBulletTypeChanged?.Invoke(this, new OnBulletTypeChangedEventArgs
            { isShotgunBullet = true });
        });

        explosion.GetComponent<Button>().onClick.AddListener(() =>
        {
            OnExplosionChanged?.Invoke(this, EventArgs.Empty);
        });

        shotgunAmmo.GetComponent<Slider>().onValueChanged.AddListener((float f) =>
        {
            OnBulletCountChanged?.Invoke(this, new OnBulletCountChangedEventArgs
            {
                bulletCount = shotgunAmmo.GetComponent<Slider>().value
            });
            OnBulletTypeChanged?.Invoke(this, new OnBulletTypeChangedEventArgs
            { isShotgunBullet = true });
        });


    }
}
