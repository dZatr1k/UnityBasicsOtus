using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    enum Screen
    {
        None,
        Main,
        Setting,
        LevelSelect
    }

    public CanvasGroup mainScreen;
    public CanvasGroup settingsScreen;
    public CanvasGroup levelSelectScreen;

    private void Start()
    {
        SetCurrentScreen(Screen.Main);
    }

    private void SetCurrentScreen(Screen screen)
    {
        Utility.SetCanvasGroupEnabled(mainScreen, screen == Screen.Main);
        Utility.SetCanvasGroupEnabled(settingsScreen, screen == Screen.Setting);
        Utility.SetCanvasGroupEnabled(levelSelectScreen, screen == Screen.LevelSelect);
    }

    public void LoadLevel(int number)
    {
        SceneManager.LoadScene(number);
    }

    public void OpenSettings()
    {
        SetCurrentScreen(Screen.Setting);
    }

    public void CloseSettings()
    {
        SetCurrentScreen(Screen.Main);
    }

    public void OpenLevelSelect()
    {
        SetCurrentScreen(Screen.LevelSelect);
    }

    public void CloseLevelSelect()
    {
        SetCurrentScreen(Screen.Main);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
