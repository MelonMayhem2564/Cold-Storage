using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class QuitToMenu : MonoBehaviour
{
    [SerializeField]
    private Scenecontroller sceneController;
    public void QuitToMainMenu()
    {
            sceneController.LoadScene("Menu");
            Cursor.lockState = CursorLockMode.None;
    }
}
