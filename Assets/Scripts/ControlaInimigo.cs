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
    private Animator _animator;
    private static readonly int Atacando = Animator.StringToHash("Atacando");

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        
        Jogador = GameObject.FindWithTag("Jogador");
        int geraTipoZumbie = UnityEngine.Random.Range(1, 28);
        transform.GetChild(geraTipoZumbie).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 zombiePosition = transform.position;
        Vector3 playerPosition = Jogador.transform.position;
        
        float distancia = Vector3.Distance(zombiePosition, playerPosition);
        
        Vector3 direcao = playerPosition - 
                          zombiePosition;
        
        Quaternion novaRotacao = Quaternion.LookRotation(direcao);
        _rigidbody.MoveRotation(novaRotacao);
        
        if (distancia > 2.5) {
            _rigidbody.MovePosition
            (_rigidbody.position + 
             direcao.normalized * (Velocidade * Time.deltaTime));
            
            _animator.SetBool(Atacando, false);
        }
        else
        {
            _animator.SetBool(Atacando, true);
        }
    }
    
    private void AtacaJogador()
    {
        Time.timeScale = 0;
        Jogador.GetComponent<ControlaJogador>().TextoGameOver.SetActive(true);
        Jogador.GetComponent<ControlaJogador>().Vivo = false;
    }
}
