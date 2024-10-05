using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementBehavior : MonoBehaviour
{
    private Vector2 _movementInput;
    private bool _jumpInput;
    private Rigidbody _rigidBody;


    public void OnMove(InputAction.CallbackContext context)
    {
        _movementInput = context.action.ReadValue<Vector3>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        _jumpInput = context.action.ReadValue<float>() > 0 ? true : false ;
    }

    private void Update()
    {
        //Debug.Log(_movementInput + " | " + _jumpInput);
    }

    private void FixedUpdate()
    {
        
    }
}
