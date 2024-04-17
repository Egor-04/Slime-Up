using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Coin : MonoBehaviour
{
    [Header("Coin Count")]
    [SerializeField] private int _coinCount;

    [Header("Money System")]
    [SerializeField] private MoneySystem _moneySystem;
    
    [Header("Jumping Text")]
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private GameObject _jumpingText;

    private void Start()
    {
        _spawnPoint = GameObject.FindGameObjectWithTag("Spawn Point").transform;
        _moneySystem = FindObjectOfType<MoneySystem>();
    }
    
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("Player"))
        {
            TMP_Text text =  Instantiate(_jumpingText, _spawnPoint).GetComponent<TMP_Text>();
            text.text = "+" + _coinCount.ToString();
            
            if (_moneySystem)
            {
                _moneySystem.AddMoney(_coinCount);
                Destroy(gameObject);
            }
        }
    }

    //private void OnTriggerExit2D(Collider2D collider2D)
    //{
    //    if (collider2D.gameObject.CompareTag("Dead Zone"))
    //    {
    //        Destroy(gameObject);
    //    }
    //}
}