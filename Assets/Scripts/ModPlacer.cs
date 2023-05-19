using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModPlacer : MonoBehaviour
{
    [SerializeField] private List<Mod> _mods;
    [SerializeField] private ModContent _modPrefab;
    [SerializeField] private RectTransform _modsHolder;
    [SerializeField] private ModView _modView;
    [SerializeField] private ScreenController _screenController;

    private void Start()
    {
        Place();
    }

    private void Place()
    {
        int childs = _modsHolder.childCount;
        ClearChilds(_modsHolder);
        for (int i = 0; i < _mods.Count; i++)
        {
            ModContent mod = Instantiate(_modPrefab, _modsHolder);
            mod.Init(_mods[i]);
            mod.Interacted += OnInteract;
        }
        childs = _modsHolder.childCount - childs;
        _modsHolder.sizeDelta = new Vector2(_modsHolder.sizeDelta.x, childs * _modPrefab.GetComponent<RectTransform>().sizeDelta.x + (childs * 80));
        _modsHolder.transform.localPosition = new(0, -_modsHolder.sizeDelta.y / 2);
    }

    private void ClearChilds(RectTransform parent)
    {
        foreach (RectTransform child in parent)
        {
            Destroy(child.gameObject);
        }
    }

    private void OnInteract(Mod mod)
    {
        _screenController.OpenScreen(WindowIdentifier.ModView);
        _modView.OpenMod(mod);
    }
}
