using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour,IInteractable
{
    public void Interact()
    {
        NextLevel();
    }

    public void NextLevel()
    {
        FindAnyObjectByType<GameManager>().currentLevel++;

        PlayerPrefs.SetInt("money",FindAnyObjectByType<Player>().money);

        PlayerPrefs.SetInt("current lvl", FindAnyObjectByType<GameManager>().currentLevel);
        PlayerPrefs.SetInt("enemy health", (int)FindAnyObjectByType<Buddy>().maxHealth + 3);
        PlayerPrefs.SetInt("enemy damage", FindAnyObjectByType<EnemyAI>().damage + 1);
        SceneManager.LoadScene(2);
    }
}
