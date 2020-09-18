using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject InGamesScreen, PausePanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PauseButton()
    {
        Time.timeScale = 0;
        InGamesScreen.SetActive(false);
        PausePanel.SetActive(true);

    }
    public void PlayButon()
    {

        Time.timeScale = 1;
        InGamesScreen.SetActive(true);
        PausePanel.SetActive(false);

    }
    public void RestartButon()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        PausePanel.SetActive(false);


    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
