using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    //private Vector2 moveDirection = Vector2.zero;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        //characterController = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Locomotion();
        Move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(Speed * Move, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isJumping == false)
        {
            rb.AddForce(new Vector2(rb.velocity.x, JumpSpeed));
            Debug.Log("jump");
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
