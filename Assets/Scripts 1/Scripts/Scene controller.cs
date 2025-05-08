using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Scenecontroller : MonoBehaviour
{
    [SerializeField]
    private float sceneFadeDuration;

    private Scenefade sceneFade;

    private void Awake()
    {
        sceneFade = GetComponentInChildren<Scenefade>();
    }

    private IEnumerator Start()
    {
        yield return sceneFade.FadeInCoroutine(sceneFadeDuration);
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneCoroutine(sceneName));
    }
    private IEnumerator LoadSceneCoroutine(string sceneName)
    {
        yield return sceneFade.FadeOutCoroutine(sceneFadeDuration);
        yield return SceneManager.LoadSceneAsync(sceneName);
    }
}
