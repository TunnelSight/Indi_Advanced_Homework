using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;

    private Vector2 curMovementInput;
    private Rigidbody _rigidbody;

    private void Awake()
    {
       _rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Move();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            curMovementInput = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
        }
    }

    void Move()
    {
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= moveSpeed;
        dir.y = _rigidbody.velocity.y;
        _rigidbody.velocity = dir;
    }

}
