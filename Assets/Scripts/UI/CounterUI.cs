using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CounterUI : MonoBehaviour
{
    public static CounterUI Instance { get; private set; }

    private TextMeshProUGUI textMesh;

    //billboard counters
    private int bulletCounter;
    private int hitCounter;

    //consts
    private const string COUNTER = "CounterImg";
    private const string TEXT = "text";

    private void Awake()
    {
        Instance = this;
        textMesh = transform.Find(COUNTER).Find(TEXT).GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        //init
        bulletCounter = 0;
        hitCounter = 0;

        UpdateBillboard();
    }
    public void BulletCreated()
    {
        bulletCounter++;
        UpdateBillboard();
    }
    public void BulletHit()
    {
        hitCounter++;
        UpdateBillboard();
    }
    private void UpdateBillboard()
    {
        //every time hit the target or summon the bullet; update the billboard
        textMesh.SetText(hitCounter.ToString() + "/" + bulletCounter.ToString());
    }
}
