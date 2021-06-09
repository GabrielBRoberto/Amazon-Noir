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

    bool pauseBool;

    private void Start()
    {
        slider.SetActive(true);
        CutSceneUI.SetActive(true);
        PauseUI.SetActive(false);
        pauseBool = false;
        Time.timeScale = 1f;
    }

    private void FixedUpdate()
    {
        if (pauseBool == false)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                slider.SetActive(false);
                CutSceneUI.SetActive(false);
                PauseUI.SetActive(true);
                Time.timeScale = 0f;
                pauseBool = true;
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
                Time.timeScale = 1f;
            }
        }
    }
    public void Back()
    {
            slider.SetActive(true);
            CutSceneUI.SetActive(true);
            PauseUI.SetActive(false);
            pauseBool = false;
            Time.timeScale = 1f;
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
