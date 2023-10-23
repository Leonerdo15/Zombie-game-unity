using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject Jogador;
    public float Velocidade = 5;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 zombiePosition = transform.position;
        Vector3 playerPosition = Jogador.transform.position;
        
        Vector3 direcao = playerPosition - 
                          zombiePosition;
        
        
        
        float distancia = Vector3.Distance(zombiePosition, playerPosition);
        
        if (distancia > 2.5) {
            _rigidbody.MovePosition
            (_rigidbody.position + 
             direcao.normalized * (Velocidade * Time.deltaTime));
            
            
            Quaternion novaRotacao = Quaternion.LookRotation(direcao);
            _rigidbody.MoveRotation(novaRotacao);
        } 
    }
}
