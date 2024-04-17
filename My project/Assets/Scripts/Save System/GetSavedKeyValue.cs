using UnityEngine;
using TMPro;

public class GetSavedKeyValue : MonoBehaviour
{
    [SerializeField] private string _keyName;
    [SerializeField] private TMP_Text _balanceText;

    private void Start()
    {
        if (PlayerPrefs.HasKey(_keyName))
        {
            _balanceText.text = PlayerPrefs.GetInt(_keyName).ToString();
        }
        else
        {
            _balanceText.text = 0.ToString();
        }
    }

    public void UpdateBalance()
    {
        if (PlayerPrefs.HasKey(_keyName))
        {
            _balanceText.text = PlayerPrefs.GetInt(_keyName).ToString();
        }
        else
        {
            _balanceText.text = 0.ToString();
        }
    }
}
