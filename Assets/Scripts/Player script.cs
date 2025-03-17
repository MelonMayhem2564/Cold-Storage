using UnityEditor;
using UnityEngine;

public class Playerscript : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;
    SpriteRenderer sr;
    float speed = 0.015f;
    Vector3 movement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Rotation();
        Jump();
    }
    void Movement()
    {
        if ((Input.GetKey("up") == true || Input.GetKey("w") == true))
        {
            transform.Translate(-speed, 0, 0);
        }
        if ((Input.GetKey("down") == true) || (Input.GetKey("s") == true))
        {
            transform.Translate(speed, 0, 0);
        }
        Rotation();
    }
    void Rotation()
    {
        if ((Input.GetKey("left") == true) || (Input.GetKey("a") == true))
        {
            transform.Rotate(0, -0.5f, 0, Space.Self);
        }
        if ((Input.GetKey("right") == true) || (Input.GetKey("d") == true))
        {
            transform.Rotate(0, 0.5f, 0, Space.Self);
        }
    }
    void Jump()
    {
        if (Input.GetKeyDown("space") == true)
        {
            rb.AddForce(0, 5, 0);
        }
    }
}
