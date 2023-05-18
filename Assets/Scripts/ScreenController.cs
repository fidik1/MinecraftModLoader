using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScreenController : MonoBehaviour
{
    [SerializeField] private GameObject[] _screens;
    [SerializeField] private int _currentScreen;
    private Vector2 _centerScreen;
    private Vector2 _edgeScreen;

    private float _animTime = 0.15f;

    private void Start()
    {
        _centerScreen = _screens[0].transform.position;
        _edgeScreen = _screens[1].transform.position;
    }

    public void OpenScreen(int screenToOpen)
    {
        _screens[screenToOpen].transform.DOMoveX(_centerScreen.x, _animTime);
        if (_currentScreen == 0 
            || _currentScreen == 1 && screenToOpen != 0
            || _currentScreen == 4 && screenToOpen != 1)
            _screens[_currentScreen].transform.position = _centerScreen;
        else
            _screens[_currentScreen].transform.DOMoveX(_edgeScreen.x, _animTime);
        _currentScreen = screenToOpen;
    }
}
