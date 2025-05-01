using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class QuitToMenu : MonoBehaviour
{
    public void QuitToMainMenu()
    {
            SceneManager.LoadScene("Menu");
            Cursor.lockState = CursorLockMode.None;
    }
}
