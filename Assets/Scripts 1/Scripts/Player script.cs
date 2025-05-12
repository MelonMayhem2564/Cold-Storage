using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Net.Sockets;

public class Playerscript : MonoBehaviour
{
    public Rigidbody rb;
    SpriteRenderer sr;
    float speed = 5f;
    Vector3 movement;
    public GameObject Player;

    [SerializeField]
    private Scenecontroller sceneController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sr = GetComponent<SpriteRenderer>();
        Player = GameObject.Find("Player");
    }
    void Update()
    {
        Movement();
        Rotation();
        QuitGame();
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
            sceneController.LoadScene("Menu");
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            AudioManager.instance.PlayClip(0);
            Destroy(Player);
            sceneController.LoadScene("Death");
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
