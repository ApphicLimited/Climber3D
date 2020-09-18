using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject MenuPanel,CompleteLevelPanel, InGamesScreen, PausePanel, GameoverPanel;
    public bool gameHasEnded;
    public float RestartDelay = 1f;
    public int currentLevel;
    public GameObject NextLevelBtn;
    public Text LevelText;
    // Start is called before the first frame update
    public void CompleteLevel()
    {
        StartCoroutine(Bitti());
        

    }
    IEnumerator Bitti()
    {
        yield return new WaitForSeconds(2);
        CompleteLevelPanel.SetActive(true);
        InGamesScreen.SetActive(false);
        Time.timeScale = 0;
        PlayerPrefs.SetInt("Level", currentLevel);
    }
    void Start()
    {
        PauseManager.FindObjectOfType<PauseManager>();
        Time.timeScale = 1;
        InGamesScreen.SetActive(false);
        currentLevel = PlayerPrefs.GetInt("Level");
       // LevelText.text = "LEVEL " + (currentLevel + 1);
        if (PlayerPrefs.GetInt("menusahne") == 1)
        {
            InGamesScreen.SetActive(true);
            MenuPanel.SetActive(false);
        }

       // Instantiate(Resources.Load("Level" + currentLevel), new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OyunAcilis()
    {
        PlayerPrefs.SetInt("menusahne", 1);
        MenuPanel.SetActive(false);
        InGamesScreen.SetActive(true);
        Time.timeScale = 1;
    }
    public void GameOver()
    {
        GameoverPanel.SetActive(true);
        PausePanel.SetActive(false);
        Time.timeScale = 0;

        }
    void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus)
        {
            PlayerPrefs.SetInt("menusahne", 0);

        }
    }
    public void seviyeAtlama()
    {

        currentLevel++;
        PlayerPrefs.SetInt("Level", currentLevel);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Invoke("Restart", RestartDelay);
        }
    }

}
