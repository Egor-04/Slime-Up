using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class SkinSwitcher : MonoBehaviour
{
    [Header("Skins Container")]
    [SerializeField] private RectTransform _skinContainer;

    [Header("Lerp Speed")]
    [SerializeField] private float _lerpSpeed = 0.1f;

    [Header("Skins")]
    [SerializeField] private PlayerSkin[] _playerSkins;

    [Header("Current Skin Number")]
    [SerializeField] private float _currentPosition = 0;
    [SerializeField] private string _savedSkinPositionKey = "RECT_SKIN_POSITION";

    [SerializeField] private int _currentIndex = 0;

    [Serializable]
    public class PlayerSkin
    {
        public int SkinID;
        public float SkinPosition;
        public string LockSkinKeyName = "";
    }

    private void Start()
    {
        _currentPosition = _playerSkins[_currentIndex].SkinPosition;
    }

    private void Update()
    {
        _currentPosition = _playerSkins[_currentIndex].SkinPosition;
        _skinContainer.anchoredPosition = Vector3.Lerp(_skinContainer.anchoredPosition, new Vector3(_playerSkins[_currentIndex].SkinPosition, 0f, 0f), _lerpSpeed * Time.deltaTime);
    }

    public void RightArrow()
    {
        _currentIndex++;
        _currentIndex = Mathf.Clamp(_currentIndex, 0, _playerSkins.Length - 1);

    }

    public void LeftArrow()
    {
        _currentIndex--;
        _currentIndex = Mathf.Clamp(_currentIndex, 0, _playerSkins.Length - 1);
    }
}