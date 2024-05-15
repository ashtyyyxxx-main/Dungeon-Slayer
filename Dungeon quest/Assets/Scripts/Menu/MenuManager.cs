using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject playMenu;
    [SerializeField] private int gameSceneId;
    [SerializeField] private Text highestScoreText;

    private int sizeDungeonX;
    private int sizeDungeonY;
    private int enemyHealth;
    private int enemyDamage;

    private void Start()
    {
        if(PlayerPrefs.HasKey("highest score"))
        {
            highestScoreText.text = "highest score: " + PlayerPrefs.GetInt("highest score") + " floors";
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void OpenPlayMenu()
    {
        ChooseEasyDifficulty();
        playMenu.SetActive(true);
    }
    public void ClosePlayMenu()
    {
        playMenu.SetActive(false);
    }
    public void Play()
    {
        PlayerPrefs.SetInt("sizeDungeonX", sizeDungeonX);
        PlayerPrefs.SetInt("sizeDungeonY", sizeDungeonY);
        PlayerPrefs.SetInt("enemy damage", enemyDamage);
        PlayerPrefs.SetInt("enemy health", enemyHealth);
        SceneManager.LoadScene(gameSceneId);
    }
    public void ChooseEasyDifficulty()
    {
        sizeDungeonX = 3;
        sizeDungeonY = 4;
        enemyHealth = 100;
        enemyDamage = 8;
    }
    public void ChooseMeduimDifficulty()
    {
        sizeDungeonX = 4;
        sizeDungeonY = 5;
        enemyHealth = 125;
        enemyDamage = 12;
    }
    public void ChooseHardDifficulty()
    {
        sizeDungeonX = 5;
        sizeDungeonY = 6;
        enemyHealth = 150;
        enemyDamage = 16;
    }
    public void ClearData()
    {
        PlayerPrefs.DeleteAll();
        highestScoreText.text = "highest score: " + 0.ToString() + " floors";
    }
}
