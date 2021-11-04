using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialController : MonoBehaviour
{
    [SerializeField] private Color mainColor = Color.white;

    private void Update()
    {
        GetComponent<Renderer>().material.color = mainColor;
    }


}
