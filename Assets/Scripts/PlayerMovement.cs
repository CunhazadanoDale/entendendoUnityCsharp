using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpHeight = 1.5f;
    public LayerMask groundLayer;
    public float groundRadius = 0.2f;
    private float gravityValue = -9.8f;

    private bool isGrounded;
    private float horizontalInput, verticalInput;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private Animator animator; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // verifica se estou no chao de fato. 
        // Vector3.down eh a direção para baixo, 
        // groundRadius eh o raio da esfera que vai verificar a colisão, 
        // e groundLayer eh a camada que representa o chão
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundRadius, groundLayer);

        playerJump(isGrounded);
        playerMove();

        // Atualiza o parâmetro "Speed" do Animator com a magnitude do vetor de movimento
        animator.SetBool("grounded", isGrounded);
    }


    public void playerMove() 
    {
        // pega o input do teclado para movimento horizontal e vertical
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // cria um vetor de movimento com base no input do teclado
        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);

        // se o vetor de movimento nao for zero, 
        // entao o personagem esta se movendo e o codigo rotaciona ele para a direcao do movimento
        if(moveDirection != Vector3.zero)
        {
            transform.forward = moveDirection;
        }

        controller.Move(moveDirection * speed * Time.deltaTime);
        animator.SetFloat("speed", moveDirection.magnitude);
    }

    public void playerJump(bool isGrounded)
    {
        // evita cair infinitamente
        // se a velocidade do jogador for negativa (caindo) e ele estiver no chão,
        // entao a velocidade do jogador eh zerada para evitar que ele caia infinitamente
        if(playerVelocity.y < 0 && isGrounded)
        {
            playerVelocity.y = 0f;
        }

        // se o jogador apertar o botao de pulo e estiver no chao,
        // entao o codigo calcula a velocidade de pulo usando a formula da fisica para pulo: v = sqrt(h * -2 * g)
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
