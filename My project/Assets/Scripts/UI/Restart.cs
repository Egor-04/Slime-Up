using UnityEngine.SceneManagement;
using UnityEngine;

public class Restart : MonoBehaviour
{
    [Header("Animation Speed")]
    [SerializeField] private float _speedAnimation = 0.3f;

    public void ButtonRestart(Animator gameOverPanel)
    {
        Time.timeScale = 1f;
        gameOverPanel.SetBool("Active", false);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("Arcade");
    }

    public void ButtonRestartMenu(string nameScene)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nameScene);
    }
}
