using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class SceneTransition : MonoBehaviour
{
    private static SceneTransition instance;

    private AsyncOperation loadingAsyncOperation;

    [SerializeField]
    private Slider slider;
    [SerializeField]
    private Image background;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Start()
    {
        HideSceneTransition();
    }

    private void Update()
    {
        if (loadingAsyncOperation  != null)
        {
            slider.DOValue(loadingAsyncOperation.progress / .8f, .3f);
        }
    }

    public static void LoadScene(string sceneName)
    {
        if (instance.background.isActiveAndEnabled)
        {
            instance.ShowSceneTransition();

            instance.loadingAsyncOperation = SceneManager.LoadSceneAsync(sceneName);
            instance.StartCoroutine(instance.Wait(.3f));
        }
        else
            SceneManager.LoadSceneAsync(sceneName);
    }

    public void ShowSceneTransition()
    {
        background.DOFade(255f, .5f);
        slider.gameObject.SetActive(true);
    }
    
    public void HideSceneTransition()
    {
        background.DOFade(0f, .5f);
        slider.gameObject.SetActive(false);
    }

    private IEnumerator Wait(float time)
    {
        instance.loadingAsyncOperation.allowSceneActivation = false;
        yield return new WaitForSeconds(time);
        instance.loadingAsyncOperation.allowSceneActivation = true;
    }
}
