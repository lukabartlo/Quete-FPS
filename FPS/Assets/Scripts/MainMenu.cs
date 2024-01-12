using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject WindowSetting;
    public GameObject WindowHelp;

    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void HelpMenu()
    {
        WindowHelp.SetActive(true);
    }

    public void CloseHelpMenu() 
    { 
        WindowHelp.SetActive(false); 
    }

    public void OptionMenu()
    {
        WindowSetting.SetActive(true);
    }

    public void CloseOptionMenu()
    {
        WindowSetting.SetActive(false);
    }

    public void QuitGame() 
    {
        Application.Quit();
    }
}
