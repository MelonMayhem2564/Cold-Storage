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
        AudioManager.instance.PlayClip(1);
    }
    public void QuitGameFromMenu()
    {
        Application.Quit();
    }
    public void Selection()
    {
        AudioManager.instance.PlayClip(0);
    }
}
