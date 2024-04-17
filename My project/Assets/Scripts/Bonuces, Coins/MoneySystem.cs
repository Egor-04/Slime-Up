using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class MoneySystem : MonoBehaviour
{
    [Header("All Moneys")]
    public int AllMoney;

    [Header("All Money Text")]
    [SerializeField] private TMP_Text _textAllMoney;

    private SaveSystem _saveSystem;

    private void Start()
    {
        _saveSystem = FindObjectOfType<SaveSystem>();
    }

    private void Update()
    {
        _textAllMoney.text = AllMoney.ToString();
    }

    public void AddMoney(int moneyCount)
    {
        AllMoney += moneyCount;
        _saveSystem.Save();
    }
}
