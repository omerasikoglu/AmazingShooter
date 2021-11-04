using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialPropertyBlockController : MonoBehaviour
{
    [SerializeField] private Color mainColor = Color.white;

    private const string COLOR = "_Color";

    private Renderer renderer;
    private MaterialPropertyBlock materialPropertyBlock;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        materialPropertyBlock = new MaterialPropertyBlock();
    }
    private void Update()
    {
        materialPropertyBlock.SetColor(name:COLOR, mainColor);
        renderer.SetPropertyBlock(materialPropertyBlock);
    }
    public void SetMainColor(Color color)
    {
        mainColor = color;
    }
}
