using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlaJogador : MonoBehaviour {
    // Update is called once per frame
    
    private static readonly int Movendo = Animator.StringToHash("Movendo");
    private Rigidbody _rigidbody;
    private Animator _animator;
    private Vector3 _moveDirection;
    [SerializeField] private float velocidade = 10;
    public LayerMask MascaraChao;
    public GameObject TextoGameOver;
    public bool Vivo = true;

    private void Start()
    {
        Time.timeScale = 1;
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update() {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        _moveDirection = Vector3.ClampMagnitude(new Vector3(horizontalInput, 0 , verticalInput), 1);
        
        if (_moveDirection != Vector3.zero) {
            _animator.SetBool(Movendo, true);
        } else {
            _animator.SetBool(Movendo, false);
        }
        
        if (Vivo == false) {
            if (Input.GetButtonDown("Fire1")) {
                SceneManager.LoadScene("game");
            }
        }
    }
    
    void FixedUpdate() {
        float verticalPreviousVelocity = _rigidbody.velocity.y;
        
        Vector3 positionIncrement = _moveDirection * velocidade;
        
        positionIncrement.y = verticalPreviousVelocity;
        
        _rigidbody.velocity = positionIncrement;
        
        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        RaycastHit impacto;
        
        Debug.DrawRay(raio.origin, raio.direction * 100, Color.red);
        
        if (Physics.Raycast(raio, out impacto, 100, MascaraChao)) {
            Vector3 posicaoMiraJogador = impacto.point - transform.position;
            posicaoMiraJogador.y = transform.position.y;
            Quaternion novaRotacao = Quaternion.LookRotation(posicaoMiraJogador);
            _rigidbody.MoveRotation(novaRotacao);
        }
    }
}
