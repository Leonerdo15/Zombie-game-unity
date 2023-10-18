using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
    // Update is called once per frame
    [SerializeField] private float speed = 10;
    private Rigidbody rb;
    private Vector3 direcao;
    
    void Start() {
        rb = GetComponent<Rigidbody>();
    }
    
    void Update() {
        Input.GetAxis("Horizontal");
        
        direcao = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }
    
    void FixedUpdate() {
        float verticalPreviousVelocity = rb.velocity.y;
        Vector3 positionIncrement = direcao * speed;
        positionIncrement.y = verticalPreviousVelocity;
        rb.velocity = positionIncrement;
    }
}
