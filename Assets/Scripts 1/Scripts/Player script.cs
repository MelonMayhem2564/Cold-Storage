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

    [SerializeField]
    private Scenecontroller sceneController;
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
            transform.Rotate(0, -1.5f, 0, Space.Self);
        }
        if ((Input.GetKey("right") == true) || (Input.GetKey("d") == true))
        {
            transform.Rotate(0, 1.5f, 0, Space.Self);
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


    void OnTriggerEnter(Collider collider)
    {

//        Debug.Log("player has collided with " + collision.gameObject.name);

        if (collider.gameObject.tag == "Enemy")
        {
            
            AudioManager.instance.PlayClip(0);
            AudioManager.instance.PlayClip(4);
            sceneController.LoadScene("Death");
            Cursor.lockState = CursorLockMode.None;
            
        }



    }

}
