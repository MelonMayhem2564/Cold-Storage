using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Net.Sockets;

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
        DeathTest();
        WinTest();
    }
    void Movement()
    {
        if ((Input.GetKey("up") == true) || (Input.GetKey("w") == true))
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
            Cursor.lockState = CursorLockMode.None;
        }
    }
    void DeathTest()
    {
        if (Input.GetKey("f") == true)
        {
            SceneManager.LoadScene("Death");
            Cursor.lockState = CursorLockMode.None;
        }
    }
    void WinTest()
    {
        if (Input.GetKey("r") == true)
        {
            SceneManager.LoadScene("Game win");
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
