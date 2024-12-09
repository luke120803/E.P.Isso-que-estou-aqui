using UnityEngine;

public class PlayerController : MonoBehaviour
{
     Rigidbody2D _playerRigidbody2D; // RigidBody do player
     float _playerSpeed = 5f;         // Velocidade do jogador
     Vector2 _playerDirection;      // Direção do movimento

    void Start()
    {
        // Pegando o componente Rigidbody2D para aplicar movimentação física
        _playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update() 
    {
        // Captura a direção do movimento baseada na entrada do usuário
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        _playerDirection = new Vector2(moveX, moveY).normalized;
        // Normaliza o vetor para evitar movimentação mais rápida em diagonais
    }

    void FixedUpdate()
    {
        // Move o jogador aplicando a direção e velocidade
        _playerRigidbody2D.MovePosition(_playerRigidbody2D.position + _playerDirection * _playerSpeed * Time.fixedDeltaTime);
    }
}