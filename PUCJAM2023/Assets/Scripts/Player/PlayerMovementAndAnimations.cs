using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementAndAnimations : MonoBehaviour
{
    private Rigidbody2D _rb;
    private SpriteRenderer _sr;
    private Animator _anim;
    private PlayerActions _actions;
    [SerializeField] float _speedModifier;
    [SerializeField] float _runMultiplier;
    private Vector2 direcao;
    private Vector2 moveVelocity;
    private Vector3 lastMovedDirection;

    private float x, y;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
        _actions = new PlayerActions();

    }
    private void OnEnable()
    {
        _actions.Enable();
    }
    private void OnDisable()
    {
        _actions.Disable();
    }

    void HandleMovementInput()
    {
        x = _actions.Movimento.LesteOeste.ReadValue<float>();
        y = _actions.Movimento.NorteSul.ReadValue<float>();

        direcao = new Vector2(x, y);
        direcao.Normalize();

        if(x != 0 || y != 0)
        {
            lastMovedDirection = direcao;
        }
    }
    void HandleMovement()
    {
        moveVelocity = direcao * _speedModifier;
        _rb.velocity = moveVelocity;
    }
    void HandleSpriteFlip()
    {
        if(lastMovedDirection.x < 0)
        {
            _sr.flipX = true;
        }
        else if(lastMovedDirection.x > 0)
        {
            _sr.flipX = false;
        }
    }

    private void Update()
    {
        HandleMovementInput();
    }
    private void FixedUpdate()
    {
        HandleMovement();
        HandleSpriteFlip();
    }
}
