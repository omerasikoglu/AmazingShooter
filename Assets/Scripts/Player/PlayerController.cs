using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    private InputReciever inputReciever;
    private Rigidbody rigodbody;

    private void Awake()
    {
        inputReciever = GetComponent<InputReciever>();
        rigodbody = GetComponent<Rigidbody>();
    }
   
    private void FixedUpdate()
    {
        Vector3 worldMoveVector = CalculateWorldMoveVector();
        SetRigidbodyVelocity(worldMoveVector);
    }

    private Vector3 CalculateWorldMoveVector()
    {
        var moveVector = new Vector3(inputReciever.HorizontalInput, 0f, inputReciever.VerticalInput);
        var worldMoveVector = transform.TransformDirection(moveVector);
        worldMoveVector = new Vector3(worldMoveVector.x, 0f, worldMoveVector.z);
        return worldMoveVector;
    }
    private void SetRigidbodyVelocity(Vector3 worldMoveVector)
    {
        rigodbody.velocity = worldMoveVector.normalized * movementSpeed;
    }


}
