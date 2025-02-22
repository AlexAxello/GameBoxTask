using System;
using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CharacterSounds))]
[RequireComponent(typeof(CharacterSounds))]
public class PlayerController : MonoBehaviour
{
    private static readonly int IsMove = Animator.StringToHash("isMove");
    private static readonly int SpeedMult = Animator.StringToHash("speedMult");
    
    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer _renderer;
    [SerializeField] private LevelManager levelManager;
    
    [Header("Movement Properties")] 
    [SerializeField] private float speed;
    [SerializeField] private bool currentFlip;
    
    [Header("Jump Properties")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float groundedOffset;
    [SerializeField] private LayerMask layerMask;
    private bool _isGrounded;

    [Header("Collider")]
    [SerializeField] private Collider2D standCollider;

    [Header("Climb Properties")] 
    public bool isClimb;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
        
        
    }

    private void Start()
    {
        FindObjectOfType<CinemachineVirtualCamera>().Follow = transform;
    }

    private void FixedUpdate()
    {
        _isGrounded = Physics2D.OverlapCircle(transform.position, groundedOffset, layerMask);
    }
    
    public void AnimStateCheck(float direction, float climbDirection, bool isRun)
    {
        _animator.SetBool(IsMove, direction != 0 && _isGrounded);
        _animator.SetFloat(SpeedMult, isRun ? 1.5f : 1);
        
        switch (direction)
        {
            case >0:
                currentFlip = false;
                break;
            case < 0:
                currentFlip = true;
                break;
        }

        _renderer.flipX = currentFlip;
    }
    
    public void Move(float direction, bool isRun, float climbSpeed)
    {
        _rb.gravityScale = isClimb ? 0 : 1;

        speed = isRun ? 6 : 4; 

        var yVelocity = _rb.velocity.y;
        
        if (isClimb)
        {
            yVelocity = climbSpeed;
        }
        
        _rb.velocity = new Vector2(direction * speed, yVelocity);
    }

    public void Jump()
    {
        if(!_isGrounded) return;

        _rb.velocity = new Vector2(_rb.velocity.x, 0);
        _rb.velocity += Vector2.up * jumpForce;
    }
}
