using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: Not working yet. Will be organized

public class BulletObjectPool : MonoBehaviour
{
    [SerializeField] private Bullet pfBullet;

    private Queue<Bullet> availableObjects = new Queue<Bullet>();

    public static BulletObjectPool Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        GrowPool(pfBullet);
    }

    public void GrowPool(Bullet bullet)
    {
        if (availableObjects.Count == 0)
        {
            for (int i = 0; i < 10; i++)
            {
                var instanceToAdd = Instantiate(bullet);
                instanceToAdd.transform.SetParent(transform);
                AddToPool(instanceToAdd);
            } 
        }
    }

    private void AddToPool(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        availableObjects.Enqueue(bullet);
    }
    public Bullet GetFromPool()
    {
        if (availableObjects.Count == 0) GrowPool(pfBullet);
        Bullet instance = availableObjects.Dequeue();
        instance.gameObject.SetActive(true);
        return instance;

    }
}
