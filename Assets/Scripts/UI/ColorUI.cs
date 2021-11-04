using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ColorUI : MonoBehaviour
{
    public event EventHandler<OnColorChangedEventArgs> OnColorChanged;
        public class OnColorChangedEventArgs : EventArgs
    {
        public Color color;
    }

    [SerializeField] private List<Transform> colors;

    private void Start()
    {
        //click the button; change the bullet color
        foreach (Transform colorTransform in colors)
        {
            colorTransform.GetComponent<Button>().onClick.AddListener(() =>
            {
                OnColorChanged?.Invoke(this, new OnColorChangedEventArgs { color = colorTransform.GetComponent<Image>().color });
            });
        }
    }


}
