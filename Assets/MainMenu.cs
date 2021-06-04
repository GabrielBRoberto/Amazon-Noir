using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenuUI;
    [SerializeField]
    private GameObject optionsUI;
    [SerializeField]
    private GameObject creditsUI;

    private void Start()
    {
        mainMenuUI.SetActive(true);
        optionsUI.SetActive(false);
        creditsUI.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Fase 1");
    }

    public void Options()
    {
        mainMenuUI.SetActive(false);
        optionsUI.SetActive(true);
    }

    public void Credits()
    {
        mainMenuUI.SetActive(false);
        creditsUI.SetActive(true);
    }

    public void Back()
    {
        optionsUI.SetActive(false);
        creditsUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
