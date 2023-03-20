using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreloaderScene : MonoBehaviour
{
    private CanvasGroup fadeGroup;
    private float loadTime;
    private float minLoadTime = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        fadeGroup = FindObjectOfType<CanvasGroup>();

        fadeGroup.alpha = 1;

        // Preload game data here
        // >

        if (Time.time < minLoadTime) {
            loadTime = minLoadTime;
        }
        else {
            loadTime = Time.time;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Fade effects on logo
        if (Time.time < minLoadTime) {
            fadeGroup.alpha = 1 - Time.time;
        }

        if (Time.time > minLoadTime && loadTime != 0) {
            fadeGroup.alpha = Time.time - minLoadTime;
            if (fadeGroup.alpha >= 1) {
                Debug.Log("Change scene: main menu");
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
