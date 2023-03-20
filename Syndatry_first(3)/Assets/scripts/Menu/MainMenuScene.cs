using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScene : MonoBehaviour
{
    private CanvasGroup fadeGroup;
    private CanvasGroup settingsGroup;
    private GameObject SettingsMenu;
    private GameObject MainMenu;
    private float fadeSpeed = 0.6f;
    // Start is called before the first frame update
    void Start()
    {
        SettingsMenu = GameObject.Find("SettingsMenu");
        SettingsMenu.SetActive(false);
        MainMenu = GameObject.Find("MainMenu");
        fadeGroup = GameObject.Find("Fade").GetComponent<CanvasGroup>();
        fadeGroup.alpha = 1;
    }

    // Update is called once per frame
    void Update()
    {
        fadeGroup.alpha = 1 - Time.timeSinceLevelLoad * fadeSpeed;
    }

    public void OnPlayClick() {
        Debug.Log("PlayButton callback");
        SceneManager.LoadSceneAsync("Loader", LoadSceneMode.Single);
    }

    public void OnSettingsClick() {
        Debug.Log("SettingsButton callback");
        SettingsMenu.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void OnSettingsCloseButtonClick() {
        MainMenu.SetActive(true);
        SettingsMenu.SetActive(false);
    }
}
