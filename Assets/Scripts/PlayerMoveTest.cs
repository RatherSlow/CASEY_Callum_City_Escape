using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PlayerMoveTest : MonoBehaviour
{
    public float PlayerMovementSpeed;
    public float PlayerJumpForce;
    public bool isJumping;
    private float _playersMovementDirection = 0;
    private PlayerInputActions _inputActionReference;
    private Rigidbody2D _playersRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        _playersRigidBody = GetComponent<Rigidbody2D>();

        _inputActionReference = new PlayerInputActions();

        _inputActionReference.Enable();

        _inputActionReference.Player.Movement.performed += moving =>
        {
            _playersMovementDirection = moving.ReadValue<float>();
        };

        _inputActionReference.Player.Jump.performed += jumping =>
        {
            JumpThePlayer();
        };

        _inputActionReference.Player.Quit.performed += Quit =>
        {
            Application.Quit();
        };
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        _playersRigidBody.velocity = new Vector2(_playersMovementDirection * 
            PlayerMovementSpeed, _playersRigidBody.velocity.y);
    }

    private void JumpThePlayer()
    {
        if (isJumping == false)
        {
            _playersRigidBody.velocity = Vector2.up * PlayerJumpForce;
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
}
