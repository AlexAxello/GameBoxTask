using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerInputs : MonoBehaviour
{
    private PlayerController _controller;
    
    private float _horizontalDirection;
    private float _verticalDirection;
    private bool _isRun;
    private bool _isJump;

    public bool IsControllable { get; set; }

    private void Start()
    {
        _controller = GetComponent<PlayerController>();
        IsControllable = true;
    }
    
    private void Update()
    {
        _horizontalDirection = Input.GetAxisRaw("Horizontal");
        _verticalDirection = Input.GetAxisRaw("Vertical");
        _isJump = Input.GetKeyDown(KeyCode.Space);
        _isRun = Input.GetKey(KeyCode.LeftShift);
        
        if (!IsControllable)
        {
            _horizontalDirection = 0;
            _verticalDirection = 0;
            _isJump = false;
            _isRun = false;
        }
        
        _controller.AnimStateCheck(_horizontalDirection, _verticalDirection, _isRun);

        if (_isJump) _controller.Jump();
    }

    private void FixedUpdate()
    {
        _controller.Move(_horizontalDirection, _isRun, _verticalDirection);
    }
}
