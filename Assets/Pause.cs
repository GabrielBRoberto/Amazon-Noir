using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField]
    GameObject slider;
    [SerializeField]
    GameObject CutSceneUI;
    [SerializeField]
    GameObject PauseUI;
    [SerializeField]
    GameObject SettingsUI;

    bool pauseBool;
    bool settingsBool;

    private void Start()
    {
        slider.SetActive(true);
        CutSceneUI.SetActive(true);
        PauseUI.SetActive(false);
        pauseBool = false;
        settingsBool = false;
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (pauseBool == false)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                slider.SetActive(false);
                CutSceneUI.SetActive(false);
                PauseUI.SetActive(true);
                Time.timeScale = 0f;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                slider.SetActive(true);
                CutSceneUI.SetActive(true);
                PauseUI.SetActive(false);
                pauseBool = false;
                settingsBool = false;
                Time.timeScale = 1f;
            }
        }
    }

    public void Settings()
    {
        PauseUI.SetActive(false);
        SettingsUI.SetActive(true);
        settingsBool = true;
        pauseBool = false;
    }
    public void Back()
    {
        if (settingsBool == true)
        {
            SettingsUI.SetActive(false);
            PauseUI.SetActive(true);
            settingsBool = false;
        }
        else
        {
            slider.SetActive(true);
            CutSceneUI.SetActive(true);
            PauseUI.SetActive(false);
            pauseBool = false;
            settingsBool = false;
            Time.timeScale = 1f;
        }
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }
    public void Exit()
    {
        Application.Quit();
    }
}
