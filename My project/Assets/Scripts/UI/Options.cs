using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Options : MonoBehaviour
{
    [Header("Messages")]
    [SerializeField] private GameObject _warningMessage;
    [SerializeField] private GameObject _exitWarningMessage;

    [Header("Options Group")]
    [SerializeField] private GameObject _optionsGroup;

    [Header("Music")]
    [SerializeField] private AudioSource _source;
    [SerializeField] private Sprite _musicONButtonSprite;
    [SerializeField] private Sprite _musicOFFButtonSprite;

    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void OpenCloseOptions()
    {
        if (_optionsGroup.activeSelf)
        {
            _optionsGroup.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0f;
            _optionsGroup.SetActive(true);
        }
    }

    public void ActivatePanel(GameObject panel)
    {
        if (!panel.activeSelf)
        {
            panel.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
        }
    }

    public void OpenMessagePanel(GameObject panel)
    {
        panel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CloseMessagePanel(GameObject warningPanel)
    {
        warningPanel.SetActive(false);
        bool isOpen = true;

        if (isOpen)
        {
            Time.timeScale = 0f;
            isOpen = false;
        }
        else
        {
            Time.timeScale = 1f;
            isOpen = true;
        }
    }

    public void OnOffMusic(Image icon)
    {
        if (icon.sprite == _musicONButtonSprite)
        {
            icon.sprite = _musicOFFButtonSprite;
            _source.mute = true;
        }
        else
        {
            icon.sprite = _musicONButtonSprite;
            _source.mute = false;
        }
    }
}
