using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.Localization.Settings;

public class ModView : MonoBehaviour
{
    private Mod _mod;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private RectTransform _screenShotsHolder;
    [SerializeField] private Image _screenShotPrefab;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private ScreenController _screenController;

    public Action<Mod> Interacted;

    public void OpenMod(Mod mod)
    {
        _mod = mod;
        _name.text = _mod.Name;
        SpawnScreenShots();
        SetDescription();
    }

    private void SpawnScreenShots()
    {
        int childs = _screenShotsHolder.childCount;
        ClearChilds(_screenShotsHolder);
        foreach (Sprite screen in _mod.ScreenShots)
        {
            Image screenShot = Instantiate(_screenShotPrefab, _screenShotsHolder);
            screenShot.sprite = screen;
        }
        childs = _screenShotsHolder.childCount - childs;
        _screenShotsHolder.sizeDelta = new Vector2(childs * _screenShotPrefab.rectTransform.sizeDelta.x + (childs + 2) * 20, _screenShotsHolder.sizeDelta.y);
    }

    private void ClearChilds(RectTransform parent)
    {
        foreach (RectTransform child in parent)
        {
            Destroy(child.gameObject);
        }
    }

    private void SetDescription()
    {
        _description.text = LocalizationSettings.StringDatabase.GetLocalizedString(_mod.DescriptionID);
    }

    public void Interact()
    {
        _screenController.OpenScreen(5);
        Interacted?.Invoke(_mod);
    }
}
