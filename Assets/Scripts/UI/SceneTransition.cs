using System.Collections;
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
        Time.timeScale = 1f;
        HideSceneTransition();
    }

    private void Update()
    {
        if (loadingAsyncOperation  != null)
        {
            slider.DOValue(loadingAsyncOperation.progress / .8f, .3f).SetUpdate(true);
        }
    }

    public static void LoadScene(string sceneName)
    {
        //SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        instance.ShowSceneTransition();
        instance.loadingAsyncOperation = SceneManager.LoadSceneAsync(sceneName);
        //instance.StartCoroutine(instance.Wait(.3f));
    }

    public void ShowSceneTransition()
    {
        background.DOFade(255f, .3f).SetUpdate(true);
        slider.gameObject.SetActive(true);
    }
    
    public void HideSceneTransition()
    {
        background.DOFade(0f, 1f).SetUpdate(true);
        slider.gameObject.SetActive(false);
    }

    private IEnumerator Wait(float time)
    {
        instance.loadingAsyncOperation.allowSceneActivation = false;
        yield return new WaitForSeconds(time);
        instance.loadingAsyncOperation.allowSceneActivation = true;
    }
}
