using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUIManager : MonoBehaviour
{
    private enum LevelPanels
    {
        None,
        Win,
        Lose,
        Pause
    }

    [SerializeField] private CanvasGroup _pausePanel;
    [SerializeField] private CanvasGroup _losePanel;
    [SerializeField] private CanvasGroup _winPanel;

    private LevelPanels _currentPanel;

    private void Start()
    {
        _currentPanel = LevelPanels.None;
        SetActivePanel(LevelPanels.None);
    }

    private void SetActivePanel(LevelPanels panel)
    {
        if (_currentPanel == LevelPanels.Win || _currentPanel == LevelPanels.Lose)
            return;

        Utility.SetCanvasGroupEnabled(_pausePanel, panel == LevelPanels.Pause);
        Utility.SetCanvasGroupEnabled(_losePanel, panel == LevelPanels.Lose);
        Utility.SetCanvasGroupEnabled(_winPanel, panel == LevelPanels.Win);

        _currentPanel = panel;
    }

    public void OpenPausePanel()
    {
        SetActivePanel(LevelPanels.Pause);
    }
    public void ClosePausePanel()
    {
        SetActivePanel(LevelPanels.None);
    }

    public void OpenWinPanel()
    {
        SetActivePanel(LevelPanels.Win);
    }

    public void OpenLosePanel()
    {
        SetActivePanel(LevelPanels.Lose);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
