using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpHeight = 1.5f;
    public LayerMask groundLayer;
    public float groundRadius = 0.2f;
    private bool isGrounded;
    private float horizontalInput, verticalInput;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private float gravityValue = -9.8f;
   


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundRadius, groundLayer);

        if(playerVelocity.y < 0 && isGrounded)
        {
            playerVelocity.y = 0f;
        }

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);

        if(moveDirection != Vector3.zero)
        {
            transform.forward = moveDirection;
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(moveDirection * speed * Time.deltaTime);
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
