using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class CheckOptionState : MonoBehaviour
{
    public enum TypeOfOption { Control, Audio }

    [Header("Info for Save")]
    public string KeyName;
    public int State;

    [Header("Audio Mixer")]
    [SerializeField] private string _tag;
    [SerializeField] private AudioMixer _audioMixer;

    [Header("Sprites")]
    [SerializeField] private Sprite _emptyCheckBox;
    [SerializeField] private Sprite _filledCheckBox;

    [Header("Radio Button On/Off")]
    [SerializeField] private Image _checkMarkOn;
    [SerializeField] private Image _checkMarkOff;

    [Header("Radio Buttons")]
    [SerializeField] private Image _firstRadiobutton;
    [SerializeField] private Image _secondRadiobutton;
    [SerializeField] private Image _thirdRadiobutton;
    
    [Header("Type of Options")]
    [SerializeField] private TypeOfOption _optionType;

    private void Start()
    {
        if (_optionType == TypeOfOption.Audio)
        {
            Audio();
        }
        else
        {
            Control();
        }
    }

    private void Control()
    {
        if (State == 0)
        {
            _firstRadiobutton.sprite = _filledCheckBox;
            _secondRadiobutton.sprite = _emptyCheckBox;
            _thirdRadiobutton.sprite = _emptyCheckBox;
        }
        else if (State == 1)
        {
            _firstRadiobutton.sprite = _emptyCheckBox;
           _secondRadiobutton.sprite = _filledCheckBox;
           _thirdRadiobutton.sprite = _emptyCheckBox;
        }
        else if (State == 2)
        {
            _firstRadiobutton.sprite = _emptyCheckBox;
            _secondRadiobutton.sprite = _emptyCheckBox;
            _thirdRadiobutton.sprite = _filledCheckBox;
        }
    }

    private void Audio()
    {
        if (State == 1)
        {
            _audioMixer.SetFloat(_tag, 0f);
            _checkMarkOn.sprite = _filledCheckBox;
            _checkMarkOff.sprite = _emptyCheckBox;
        }
        else if (State == 0)
        {
            _audioMixer.SetFloat(_tag, -80f);
            _checkMarkOn.sprite = _emptyCheckBox;
            _checkMarkOff.sprite = _filledCheckBox;
        }
    }
}
