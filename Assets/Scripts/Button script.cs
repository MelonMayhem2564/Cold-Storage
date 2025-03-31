using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;
using UnityEngine.SceneManagement;



public class Buttonscript : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
        AudioManager.instance.PlayClip(0);
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void QuitGameFromMenu()
    {
        Application.Quit();
        AudioManager.instance.PlayClip(2);
    }
    public void Selection()
    {
        AudioManager.instance.PlayClip(1);
    }
    public void Unselection()
    {
        AudioManager.instance.PlayClip(2);
    }
    public void Secret()
    {
        AudioManager.instance.PlayClip(0);
    }
}
