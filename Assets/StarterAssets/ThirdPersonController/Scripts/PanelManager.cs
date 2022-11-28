using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    public Button pause;
    public Button resume;
    public Button quit;
    public Button startGame;
    public Button underStood;
    public GameObject pausePanel;
    public GameObject startGamePanel;
    public GameObject instructionPanel;

    private void Start()
    {
        pause.onClick.AddListener(PausePanel);
        resume .onClick.AddListener(Resume);
        quit.onClick.AddListener(Quit);
        startGame .onClick.AddListener(StartGame);
        underStood.onClick.AddListener(UnderStood);
    }

    private void PausePanel()
    {
        pausePanel.SetActive(true);
        Time.timeScale  = 0f;
    }
    private void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    private void Quit()
    {
        Application.Quit();
    }
    private void StartGame()
    {
        instructionPanel.SetActive(true);
        startGamePanel.SetActive(false);
       
        
    }
    private void UnderStood()
    {
        instructionPanel.SetActive(false );
        
    }
}
