using UnityEngine.EventSystems;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class CheckMarkOff : MonoBehaviour, IPointerDownHandler
{
    [Header("Current CheckBox")]
    [SerializeField] private Image _currentCheckBox;

    [Header("States of Sprites")]
    [SerializeField] private Sprite _emptyCheckBoxSprite;
    [SerializeField] private Sprite _filledCheckBoxSprite;

    [Header("Audio Mixer")]
    [SerializeField] private string _tag;
    [SerializeField] private AudioMixer _audioMixerGroup;

    [Header("Options State")]
    [SerializeField] private CheckOptionState _checkOptionState;

    [Header("Check Boxes")]
    [SerializeField] private Image[] _checkBoxes;

    public void OnPointerDown(PointerEventData eventData)
    {
        DisableAll();
        _currentCheckBox.sprite = _filledCheckBoxSprite;
        Audio();
    }

    private void Audio()
    {
        _audioMixerGroup.SetFloat(_tag, -80f);
        _checkOptionState.State = 0;
    }

    private void DisableAll()
    {
        for (int i = 0; i < _checkBoxes.Length; i++)
        {
            _checkBoxes[i].sprite = _emptyCheckBoxSprite;
        }
    }
}