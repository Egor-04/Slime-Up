using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class RecordSystem : MonoBehaviour
{
    [Header("Max Record")]
    public int MaxRecord;

    [Header("Text")]
    [SerializeField] private TMP_Text _textMaxRecordHeight;

    private SaveSystem _saveSystem;

    private void Start()
    {
        _saveSystem = FindObjectOfType<SaveSystem>();
    }

    private void Update()
    {
        _textMaxRecordHeight.text = string.Format("{0:0m}", MaxRecord);
    }

    public void GetMaxRecord(int currentPlayerHeight)
    {
        if (currentPlayerHeight > MaxRecord)
        {
            MaxRecord = currentPlayerHeight;
            _saveSystem.Save();
        }
    }
}