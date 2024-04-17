using UnityEngine;

public class SkinScaler : MonoBehaviour
{
    [Header("Lerp Speed")]
    [SerializeField] private float _lerpSpeed = 0.03f;

    private RectTransform _currentSkin;
    [SerializeField] private Vector2 _cachedSkinScale;

    private void Start()
    {
        _currentSkin = GetComponent<RectTransform>();
        _cachedSkinScale = _currentSkin.localScale;
    }

    private void Update()
    {
        _currentSkin.localScale = Vector3.Lerp(_currentSkin.localScale, _cachedSkinScale, _lerpSpeed);
    }
}
