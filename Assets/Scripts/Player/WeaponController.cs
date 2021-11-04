using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class WeaponController : MonoBehaviour
{
    private InputReciever inputReciever;
    private Gun gun;

    private void Awake()
    {
        inputReciever = GetComponent<InputReciever>();
        gun = GetComponent<Gun>();
    }
    private void Update()
    {
        if (HandleShooting() && !EventSystem.current.IsPointerOverGameObject())
        {
            gun.Attack();
        }
    }

    private bool HandleShooting()
    {
        return inputReciever.IsShooting;
    }
}
