using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMovement : MonoBehaviour
{
    public float WorldSpeed;    

    private Rigidbody2D wrb;
    // Start is called before the first frame update
    void Start()
    {
        wrb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        wrb.velocity = new Vector2(WorldSpeed, wrb.velocity.y);
    }
}
