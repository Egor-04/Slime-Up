using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class SwitchArrows : MonoBehaviour
{
    [Header("Max & Min Pages")]
    [SerializeField] private int _minPages = 0;
    [SerializeField] private int _maxPages = 1;

    [Header("Current Page Number")]
    [SerializeField] private int _currentPageNumber = 0;
    
    [Header("All Pages")]
    [SerializeField] private GameObject[] _pages;

    private void Update()
    {
        _currentPageNumber = Mathf.Clamp(_currentPageNumber, _minPages, _maxPages);
    }

    public void RightArrow()
    {
        if (_currentPageNumber != _maxPages)
        {
            DisableAll();

            _currentPageNumber++;
            _pages[_currentPageNumber].SetActive(true);
        }
    }

    public void LeftArrow()
    {
        if (_currentPageNumber != _minPages)
        {
            DisableAll();

            _currentPageNumber--;
            _pages[_currentPageNumber].SetActive(true);
        }
    }

    private void DisableAll()
    {
        for (int i = 0; i < _pages.Length; i++)
        {
            _pages[i].SetActive(false);
        }
    }
}