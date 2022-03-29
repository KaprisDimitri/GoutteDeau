using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private CharacterController _characterController;
    private float _speed = 5.0f;
    private Vector2 _playerMovementInput;


    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector3 movement = new Vector3(_playerMovementInput.x, 0.0f, _playerMovementInput.y);

        _characterController.SimpleMove(movement * _speed);
    }

    void OnMove(InputValue iv)
    {
        _playerMovementInput = iv.Get<Vector2>();
    }
}