using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    PlayerInputActions input;
    Animator anim;
    Rigidbody rigid;

    float currentMoveSpeed;
    float moveDirection;

    readonly int MoveHash = Animator.StringToHash("Moving");
    readonly int RunHash = Animator.StringToHash("Running");

    private void Awake()
    {
        input = new PlayerInputActions();
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        input.Player.Enable();
        input.Player.Move.performed += OnMoveInput;
        input.Player.Move.canceled += OnMoveInput;
    }

    private void OnDisable()
    {
        input.Player.Move.canceled -= OnMoveInput;
        input.Player.Move.performed -= OnMoveInput;
        input.Player.Disable();
    }

    private void FixedUpdate()
    {
        rigid.MovePosition(Time.fixedDeltaTime * currentMoveSpeed * moveDirection * transform.forward);
    }

    private void OnMoveInput(InputAction.CallbackContext context)
    {
        SetDirection(context.ReadValue<Vector2>(), !context.canceled);
    }

    void SetDirection(Vector2 input, bool isMove)
    {
        moveDirection = input.y;

        anim.SetBool(MoveHash, isMove);
    }

}
