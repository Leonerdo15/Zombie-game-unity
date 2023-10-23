using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public float Velocidade = 20;

    // Update is called once per frame
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        _rigidbody.MovePosition
            (_rigidbody.position + 
             transform.forward * (Velocidade * Time.deltaTime));
    }
}
