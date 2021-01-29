using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public bool hasPauseMenu = false;
    private KeyCode _pauseKey = KeyCode.Escape;

    public GameObject _pauseMenu;

    private void Update()
    {
        if(hasPauseMenu && Input.GetKeyDown(_pauseKey))
        {
            _pauseMenu.SetActive(true);
        }
    }

    public void LoadScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void OpenSite(string url)
    {
        Application.OpenURL(url);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
