using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

//[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    //CharacterController characterController;
    public float Speed;
    public float JumpSpeed;
    public bool isJumping;
    //public float gravity;
    private float Move;
    private float Maxspeed;    

    private Rigidbody2D rb;
    private PlayerInput playerInput;    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        //characterController = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();

        PlayerInputActions playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Jump.performed += Jump;
        playerInputActions.Player.Quit.performed += Quit;
    }

    // Update is called once per frame
    void Update()
    {
        //Locomotion();
        Move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(Speed * Move, rb.velocity.y);

        //if (Input.GetButtonDown("Jump") && isJumping == false)
        //{
        //    rb.AddForce(new Vector2(rb.velocity.x, JumpSpeed));
        //    Debug.Log("jump");
        //}
    }
    
    //using unity events
    public void Jump(InputAction.CallbackContext context)
    {
        if (//Input.GetButtonDown("Jump")  &&
            context.performed && isJumping == false)
        {
            Debug.Log("jump " + context.phase);
            rb.AddForce(new Vector2(rb.velocity.x, JumpSpeed));            
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }

    public void Quit(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("quit " + context.phase);
            Application.Quit();
        }
    }

    //void Locomotion()
    //{
    //if (characterController.isGrounded)
    //{
    //moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    //moveDirection = transform.TransformDirection(moveDirection);
    //moveDirection *= Speed;
    //}
    //moveDirection.y -= gravity * Time.deltaTime;
    //characterController.Move(moveDirection * Time.deltaTime);
    //}
}
