using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public GameObject panelSettings;
    
    private void Start()
    {
        if (panelSettings != null)
        {
            panelSettings.SetActive(false);
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Settings()
    {
        if (panelSettings == null)
        {
            return;
        }

        if (panelSettings.activeSelf == false)
        {
            panelSettings.SetActive(true);
        }
        else
        {
            panelSettings.SetActive(false);
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}