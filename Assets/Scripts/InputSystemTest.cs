using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystemTest : MonoBehaviour
{
    private Rigidbody2D squareRigidBody;

    private void Awake()
    {
        squareRigidBody = GetComponent<Rigidbody2D>();
    }
    public void Jump()
    {
        Debug.Log("Jump!");
        squareRigidBody.AddForce(new Vector2(1f, 4f));
    }
}
