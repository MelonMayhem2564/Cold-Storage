using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Playerscript : MonoBehaviour
{
    Rigidbody rb;
    SpriteRenderer sr;
    float speed = 5f;
    Vector3 movement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Movement();
        Rotation();
        QuitGame();
    }
    void Movement()
    {
        if ((Input.GetKey("up") == true || Input.GetKey("w") == true))
        {
            rb.linearVelocity = transform.forward * speed;
        }
        if ((Input.GetKey("down") == true) || (Input.GetKey("s") == true))
        {
            rb.linearVelocity = -transform.forward * speed;
        }
    }
    void Rotation()
    {
        if ((Input.GetKey("left") == true) || (Input.GetKey("a") == true))
        {
            transform.Rotate(0, -1f, 0, Space.Self);
        }
        if ((Input.GetKey("right") == true) || (Input.GetKey("d") == true))
        {
            transform.Rotate(0, 1f, 0, Space.Self);
        }
    }
    void QuitGame()
    {
        if (Input.GetKey("q") == true)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
