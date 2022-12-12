using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject SettingPanel;
    [SerializeField] private GameObject MainMenuPanel;

    public void Exit()
    { 
        Application.Quit();
    }
    public void Settings()
    {
        MainMenuPanel.SetActive(!MainMenuPanel.activeSelf);
        SettingPanel.SetActive(!SettingPanel.activeSelf);       
    }
    public void Play()
    {
        SceneManager.LoadScene(0);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!MainMenuPanel.activeSelf)
            { 
                SettingPanel.SetActive(false);
                MainMenuPanel.SetActive(true);
            }
        }
    }
}
