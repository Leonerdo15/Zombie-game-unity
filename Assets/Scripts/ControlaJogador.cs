using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
    // Update is called once per frame
    
    private static readonly int Movendo = Animator.StringToHash("Movendo");
    private Rigidbody _rigidbody;
    private Animator _animator;
    private Vector3 moveDirection;
    [SerializeField] private float velocidade = 10;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update() {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        moveDirection = Vector3.ClampMagnitude(new Vector3(horizontalInput, 0 , verticalInput), 1);
        
        if (moveDirection != Vector3.zero) {
            _animator.SetBool(Movendo, true);
        } else {
            _animator.SetBool(Movendo, false);
        }
    }
    
    void FixedUpdate() {
        float verticalPreviousVelocity = _rigidbody.velocity.y;
        
        Vector3 positionIncrement = moveDirection * velocidade;
        
        positionIncrement.y = verticalPreviousVelocity;
        
        _rigidbody.velocity = positionIncrement;
    }
}
