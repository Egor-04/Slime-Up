using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class SwipeControll : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("Number Controll")]
    [SerializeField] private int _controllNumber = 1;

    [Header("Key Controll")]
    [SerializeField] private string _keyControll = "CURRENT_CONTROLL_MODE";

    [Header("Swipe Controll")]
    [SerializeField] private Vector2 _swipeDirection;
    [SerializeField] private float _swipeValue;
    [SerializeField] private float _swipeSensitivitySpeed = 30f;

    [SerializeField] private Image _tapImage;
    [SerializeField] private Image _tapPanel;

    private int _currentModeValue;

    private void Start()
    {
        _tapPanel = GetComponent<Image>();

        _currentModeValue = PlayerPrefs.GetInt(_keyControll);

        if (_currentModeValue == _controllNumber)
        {
            enabled = true;
        }
        else
        {
            enabled = false;
        }
    }
 
    public void OnBeginDrag(PointerEventData eventData)
    {
        _swipeValue = 0f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        SwipeMode();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _swipeValue = 0f;
        _swipeDirection = Vector2.zero;
        _tapImage.rectTransform.anchoredPosition = Vector2.zero;
    }

    public void SwipeMode()
    {
        if (enabled)
        {
            _tapImage.rectTransform.position = Input.mousePosition;
            _swipeValue = new Vector2(_tapImage.rectTransform.anchoredPosition.x / _tapPanel.rectTransform.rect.width / 0.2f, 0f).x;
            _swipeDirection = new Vector2(_swipeValue * _swipeSensitivitySpeed, 0f);
        }
    }

    public float SwipeValue()
    {
        return _swipeDirection.x;
    }
}
