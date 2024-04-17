using UnityEngine;

public class ScaleTrigger : MonoBehaviour
{
    [Header("Lerp Speed")]
    [SerializeField] private float _lerpSpeed = 0.02f;

    [Header("Scale")]
    [SerializeField] private Vector3 _skinScale;

    [Header("Skin")]
    [SerializeField] private RectTransform _currentSkin;

    private void Update()
    {
        _currentSkin.localScale = Vector3.Lerp(_currentSkin.localScale, _skinScale, _lerpSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.GetComponent<SkinScaler>())
        {
            _currentSkin = collider2D.GetComponent<RectTransform>();
        }
    }
}
