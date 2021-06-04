using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField]
    GameObject menuUI, settingUI, creditsUI;

    private void Start()
    {
        menuUI.SetActive(true);
        settingUI.SetActive(false);
        creditsUI.SetActive(false);
    }

    public void Setting()
    {
        menuUI.SetActive(false);
        settingUI.SetActive(false);
        creditsUI.SetActive(false);
    }
}
