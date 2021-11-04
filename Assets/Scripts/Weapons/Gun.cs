using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Gun : MonoBehaviour
{
    //events
    public event EventHandler OnBulletCreated;
    public event EventHandler OnBulletHitEnemy;

    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private Transform firePoint;

    [SerializeField] private ColorUI colorUI;
    [SerializeField] private BulletTypeUI bulletTypeUI;

    private Color bulletColor;
    private bool isShotgunBullet;
    private bool isExplosionBullet;
    private int bulletCount;

    private void Start()
    {
        //observer
        colorUI.OnColorChanged += ColorUI_OnColorChanged;
        bulletTypeUI.OnBulletTypeChanged += BulletTypeUI_OnBulletTypeChanged;
        bulletTypeUI.OnBulletCountChanged += BulletTypeUI_OnBulletCountChanged;
        bulletTypeUI.OnExplosionChanged += BulletTypeUI_OnExplosionChanged;

        //pre values
        isShotgunBullet = false;
        bulletCount = 1;
        isExplosionBullet = false;
        bulletColor = Color.black;
    }

    #region Observer
    private void BulletTypeUI_OnExplosionChanged(object sender, EventArgs e)
    {
        isExplosionBullet = !isExplosionBullet;
    }

    private void BulletTypeUI_OnBulletCountChanged(object sender, BulletTypeUI.OnBulletCountChangedEventArgs e)
    {
        bulletCount = (int)e.bulletCount;
    }

    private void BulletTypeUI_OnBulletTypeChanged(object sender, BulletTypeUI.OnBulletTypeChangedEventArgs e)
    {
        isShotgunBullet = e.isShotgunBullet;
    }

    private void ColorUI_OnColorChanged(object sender, ColorUI.OnColorChangedEventArgs e)
    {
        bulletColor = e.color;
    }

    #endregion

    public void Attack()
    {
        if (isShotgunBullet)
        {
            for (int i = 0; i < bulletCount; i++)
            {
                Bullet.Create(this);
            }
        }
        else
        {
            Bullet.Create(this);
        }
    }
    public bool GetIsExplosionBullet()
    {
        return isExplosionBullet;
    }
    public bool GetIsShotgunBullet()
    {
        return isShotgunBullet;
    }
    public Vector3 GetFirePosition()
    {
        return firePoint.transform.position;
    }
    public Color GetColor()
    {
        return bulletColor;
    }
    public float GetBulletSpeed()
    {
        return bulletSpeed;
    }

}
