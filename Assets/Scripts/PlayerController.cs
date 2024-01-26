using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isGround;
    //float gravity = 5;

    public Rigidbody2D rb;
    float speed = 5;
    Vector2 moveAxis;
    void Update()
    {
        moveAxis = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveAxis = Vector3.ClampMagnitude(moveAxis, 1);
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + (moveAxis * speed * Time.fixedDeltaTime));
    }

}
