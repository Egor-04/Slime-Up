using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class CheckMarkThird : MonoBehaviour, IPointerDownHandler
{
    public enum TypeOfCheck { Control, Audio }

    [Header("Entered State Value")]
    [SerializeField] private int _currentState;

    [Header("Current Radio Button")]
    [SerializeField] private Image _currentCheckBox;

    [Header("States of Sprites")]
    [SerializeField] private Sprite _emptyCheckBoxSprite;
    [SerializeField] private Sprite _filledCheckBoxSprite;

    [Header("Options State")]
    [SerializeField] private CheckOptionState _checkOptionState;

    [Header("Check Boxes")]
    [SerializeField] private Image[] _checkBoxes;

    public void OnPointerDown(PointerEventData eventData)
    {
        DisableAll();
        _currentCheckBox.sprite = _filledCheckBoxSprite;
        Control();
    }

    private void Control()
    {
        _checkOptionState.State = _currentState;
    }

    private void DisableAll()
    {
        for (int i = 0; i < _checkBoxes.Length; i++)
        {
            _checkBoxes[i].sprite = _emptyCheckBoxSprite;
        }
    }
}
