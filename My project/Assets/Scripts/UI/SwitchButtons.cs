using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SwitchButtons : MonoBehaviour
{
    [Header("Current Button")]
    [SerializeField] private Image _currentButton;

    [Header("Sprites States")]
    [SerializeField] private Sprite _clicked;
    [SerializeField] private Sprite _notClicked;

    [Header("All Buttons")]
    [SerializeField] private Image[] _allButtons;

    [Header("All Panels")]
    [SerializeField] private GameObject[] _panels;

    public void EnablePanel(GameObject panel)
    {
        DisableAllPanels();
        DisableAllButtons();
        
        panel.SetActive(true);

        _currentButton.sprite = _clicked;
    }

    private void DisableAllPanels()
    {
        for (int i = 0; i < _panels.Length; i++)
        {
            _panels[i].SetActive(false);
        }
    }

    private void DisableAllButtons()
    {
        for (int i = 0; i < _allButtons.Length; i++)
        {
            _allButtons[i].sprite = _notClicked;
        }
    }
}
