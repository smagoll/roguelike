using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerMenu : MonoBehaviour
{
    public void ButtonPlay()
    {
        SceneManager.LoadScene("Game");
    }
}
