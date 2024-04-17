using UnityEngine.EventSystems;
using UnityEngine;

public enum TouchType { Left, Right};
public class TouchController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private TouchType _touchType;
    [SerializeField] private TouchValue _touchValue;

    public void OnPointerDown(PointerEventData eventData)
    {
        _touchValue.Direction = Direction();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _touchValue.Direction = 0;
    }

    public int Direction()
    {
        int direction;

        if (_touchType == TouchType.Left)
        {
            direction = Left();
            return direction;
        }
        else
        {
            direction = Right();
            return direction;
        }

    }

    private int Left()
    {
        int direction = -1;
        return direction;
    }

    private int Right()
    {
        int direction = 1;
        return direction;
    }
}
