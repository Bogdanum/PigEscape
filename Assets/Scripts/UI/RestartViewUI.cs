using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartViewUI : MonoBehaviour
{
    [SerializeField, Space(10)]
    private GameObject restartHud,
                       gameOverSound;

    public void ShowRestartHud()
    {
        restartHud.SetActive(true);
        Instantiate(gameOverSound, transform);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
