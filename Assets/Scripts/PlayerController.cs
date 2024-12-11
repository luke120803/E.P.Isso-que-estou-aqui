using UnityEngine;

public class PlayerController : MonoBehaviour
{
     private Rigidbody2D _playerRigidbody2D; // RigidBody do player
     private Animator _playerAnimator;
     public float _playerSpeed;       // Velocidade do jogador
     private Vector2 _playerDirection;      // Direção do movimento

    void Start()
    {
        // Pegando o componente Rigidbody2D para aplicar movimentação física
        _playerRigidbody2D = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();
    }

    void Update() 
    {
        // Captura a direção do movimento baseada na entrada do usuário
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        _playerDirection = new Vector2(moveX, moveY).normalized;
        
        if (_playerDirection.sqrMagnitude > 0)
        {
            _playerAnimator.SetInteger("Movimento", 1);
        }
        else
        {
            _playerAnimator.SetInteger("Movimento", 0);
        }
        
        Flip();
    }

    void FixedUpdate()
    {
        // Move o jogador aplicando a direção e velocidade
        _playerRigidbody2D.MovePosition(_playerRigidbody2D.position + _playerDirection * _playerSpeed * Time.fixedDeltaTime);
    }

    void Flip()
    {
        if (_playerDirection.x > 0)
        {
            transform.eulerAngles = new Vector2(0f,0f);
        }
        else if (_playerDirection.x < 0)
        {
            transform.eulerAngles = new Vector2(0f,180f);
        }
    }
}