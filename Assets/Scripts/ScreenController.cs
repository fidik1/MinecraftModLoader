using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public sealed class ScreenController : MonoBehaviour
{
    [SerializeField] private List<GameScreen> _screens;
    [SerializeField] private GameScreen _currentScreen;
    private Vector2 _centerScreen;
    private Vector2 _edgeScreen;

    private float _animTime = 0.15f;

    private static ScreenController _instance;

    private ScreenController() { }

    private void Awake()
    {
        if (_instance == null) _instance = this;
    }

    public static ScreenController GetInstance() => _instance;

    private void Start()
    {
        _centerScreen = _screens[GetScreenIndex(WindowIdentifier.Main)].transform.position;
        _edgeScreen = _screens[GetScreenIndex(WindowIdentifier.Mods)].transform.position;
    }

    public void OpenScreen(WindowIdentifier screenToOpen)
    {
        GameScreen screen = _screens[GetScreenIndex(screenToOpen)];
        screen.transform.DOMoveX(_centerScreen.x, _animTime);
        if (_currentScreen.Value > screen.Value)
            _currentScreen.transform.position = _centerScreen;
        else
            _currentScreen.transform.DOMoveX(_edgeScreen.x, _animTime);
        _currentScreen = screen;
    }

    private int GetScreenIndex(WindowIdentifier screen) => _screens.IndexOf(_screens.Where(s => s.ID == screen).Last());  
}
