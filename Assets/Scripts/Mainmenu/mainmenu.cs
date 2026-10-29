using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public GameObject panelSettings;
    
    private void Start()
    {
        Debug.Log("Main Menu Loaded");
        if (panelSettings != null)
        {
            panelSettings.SetActive(false);
        }
    }

    public void Play()
    {
        Debug.Log("Play button clicked");
        SceneManager.LoadScene("SampleScene");
    }
    public void Back()
    {
        Debug.Log("Back to Main Menu");
        SceneManager.LoadScene("MainMenu");
    }
    public void Settings()
    {
        Debug.Log("Settings button clicked");
        if (panelSettings == null)
        {
            return;
        }

        if (panelSettings.activeSelf == false)
        {
            Debug.Log("Settings panel activated");
            panelSettings.SetActive(true);
        }
        else
        {
            Debug.Log("Settings panel deactivated");
            panelSettings.SetActive(false);
        }
    }

    public void Exit()
    {
        Debug.Log("Exit button clicked");
        Application.Quit();
    }
}