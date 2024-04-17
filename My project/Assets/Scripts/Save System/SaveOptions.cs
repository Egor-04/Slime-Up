using UnityEngine;
using System;

public class SaveOptions : MonoBehaviour
{
    [SerializeField] private OptionObject[] _optionObjects;

    [Serializable]
    public class OptionObject
    {
        public CheckOptionState CheckOptionState;
        [SerializeField] private string _keyName;
        [SerializeField] private int _stateInfo;

        public void SetInfo()
        {
            _keyName = CheckOptionState.KeyName;
            _stateInfo = CheckOptionState.State;
        }

        public void Save()
        {
            SetInfo();
            PlayerPrefs.SetInt(_keyName, _stateInfo);
            Load();
        }

        public void Load()
        {
            if (PlayerPrefs.HasKey(_keyName))
            {
                Debug.Log("I LOAD");
                CheckOptionState.State = PlayerPrefs.GetInt(_keyName);
            }
        }
    }

    private void Start()
    {
        SetSaveInfo();
        Load();
    }

    public void SetSaveInfo()
    {
        for (int i = 0; i < _optionObjects.Length; i++)
        {
            _optionObjects[i].SetInfo();
        }
    }

    public void Save()
    {
        for (int i = 0; i < _optionObjects.Length; i++)
        {
            _optionObjects[i].Save();
        }
    }

    public void Load()
    {
        for (int i = 0; i < _optionObjects.Length; i++)
        {
            _optionObjects[i].Load();
        }
    }
}
