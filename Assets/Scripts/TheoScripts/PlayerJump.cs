using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerJump : MonoBehaviour
{
    private CharacterController _characterController;

    // jump variables
    private Vector3 _playerVelocity;
    private bool _groundedPlayer;

    [SerializeField] private float _jumpHeight = 5.0f;
    private bool _jumpedPressed = false;
    private float _gravityValue = -9.81f;
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }


    void Update()
    {
        MovementJump();
    }

    void MovementJump()
    {
        _groundedPlayer = _characterController.isGrounded;

        // si on the ground alors stop le movement vertical
        if (_groundedPlayer)
        {
            _playerVelocity.y = 0.0f;
        }

        // si jump pressed et on the ground
        if (_jumpedPressed && _groundedPlayer)
        {
            _playerVelocity.y += Mathf.Sqrt(_jumpHeight * -1.0f * _gravityValue);
            _jumpedPressed = false;
        }

        _playerVelocity.y += _gravityValue * Time.deltaTime;
        _characterController.Move(_playerVelocity * Time.deltaTime);
    }

    void OnJump()
    {
        Debug.Log("Jump pressed");

        //check si pas de movement vertical
        if (_characterController.velocity.y == 0)
        {
            Debug.Log("can jump");
            _jumpedPressed = true;
        }
        else
        {
            Debug.Log("cannot jump");
        }
    }
}