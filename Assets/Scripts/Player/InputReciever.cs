using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReciever : MonoBehaviour
{
    //command pattern
    [SerializeField] private KeyCode shootingButton;

    private const string HORIZONTAL = "Horizontal";
    private const string VERRICAL = "Vertical";

    public bool IsShooting { get; private set; }
    public float HorizontalInput { get; private set; }
    public float VerticalInput { get; private set; }
    private void Update()
    {
        ReceiveAxisInput();
        ReceiveButtonsInput();
    }
    private void ReceiveAxisInput()
    {
        HorizontalInput = Input.GetAxis(HORIZONTAL);
        VerticalInput = Input.GetAxis(VERRICAL);
    }
    private void ReceiveButtonsInput()
    {
        IsShooting = Input.GetKeyDown(shootingButton);
    }


}
