using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject itemHotbar;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject deathMenu;
    [SerializeField] private GameObject healthObj;
    [SerializeField] private GameObject moneyObj;
    [SerializeField] private Text currentLvlText;

    public int currentLevel;
    public int highestScore;

    private Player player;

    private void Start()
    {
        //Time.timeScale = 1;

        currentLevel = PlayerPrefs.GetInt("current lvl");

        player = FindAnyObjectByType<Player>();
        player.onDeath += OpenDeathMenu;

        if(PlayerPrefs.HasKey("highest score"))
        {
            highestScore = PlayerPrefs.GetInt("highest score");
        }
        else
        {
            highestScore = 0;
        }

        currentLvlText.text = "current lvl: " + currentLevel.ToString();
    }

    private void OpenDeathMenu()
    {
        //ExitToMainMenu();
        deathMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        
        itemHotbar.SetActive(false);
        healthObj.SetActive(false);
        moneyObj.SetActive(false);
    }

    public void ExitToMainMenu()
    {
        PlayerPrefs.SetInt("current lvl", 0);
        PlayerPrefs.SetInt("money", 0);

        if(highestScore == 0)
        {
            highestScore = currentLevel;
            PlayerPrefs.SetInt("highest score", highestScore);
        }
        if(currentLevel >= highestScore)
        {
            PlayerPrefs.SetInt("highest score", currentLevel);
        }

        SceneManager.LoadScene(0);
    }

    private bool pauseMenuActive;
    public void OpenPauseMenu()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        pauseMenuActive = true;
        Time.timeScale = 0;

        TurnOffUI();

        pauseMenu.SetActive(true);
    }
    public void ClosePauseMenu()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        pauseMenuActive = false;
        Time.timeScale = 1;

        TurnOnUI();

        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && pauseMenuActive)
        {
            ClosePauseMenu();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && !pauseMenuActive)
        {
            OpenPauseMenu();
        }
    }

    public void TurnOffUI()
    {
        itemHotbar.SetActive(false);
        healthObj.SetActive(false);
        moneyObj.SetActive(false);
    }
    public void TurnOnUI()
    {
        itemHotbar.SetActive(true);
        healthObj.SetActive(true);
        moneyObj.SetActive(true);
    }
}
