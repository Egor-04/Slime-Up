using UnityEngine.UI;
using UnityEngine;
using System;
using TMPro;

public class AdventureLevelsUnlocker : MonoBehaviour
{
    [Header("Current Max Height")]
    [SerializeField] private int _recordHeight;

    [Header("Levels")]
    [SerializeField] private Level[] _levels;

    [Serializable]
    public class Level 
    {
        [Header("Value")]
        public int NeedRecordHeight;
        public int CurrentRecordHeight;

        [Header("Button")]
        public Button CurrentPlayButton;
        
        [Header("Sprites")]
        public Image CurrentButtonSprite;
        public Sprite UnlockedSprite;
        public Sprite LockedSprite;

        [Header("Text")]
        [SerializeField] private TMP_Text TextState;

        [SerializeField] private bool _canUnlockLevel;

        public bool CheckHeightToUnlock(bool canUnlock)
        {
            if (CurrentRecordHeight >= NeedRecordHeight)
            {
                _canUnlockLevel = true;
                return _canUnlockLevel;
            }
            else
            {
                _canUnlockLevel = false;
                return _canUnlockLevel;
            }
        }

        public void CheckLevelLockMode()
        {
            CheckHeightToUnlock(_canUnlockLevel);

            if (_canUnlockLevel)
            {
                CurrentPlayButton.enabled = true;
                CurrentButtonSprite.sprite = UnlockedSprite;
                TextState.text = "Play";
            }
            else
            {
                CurrentPlayButton.enabled = false;
                CurrentButtonSprite.sprite = LockedSprite;
                TextState.text = "Locked";
            }
        }
    }

    private void Start()
    {
        _recordHeight = PlayerPrefs.GetInt("MAX_HEIGHT_RECORD");
        CheckUnlockedLevels();
    }

    private void CheckUnlockedLevels()
    {
        for (int i = 0; i < _levels.Length; i++)
        {
            _levels[i].CurrentRecordHeight = _recordHeight;
            _levels[i].CheckLevelLockMode();
        }
    }
}