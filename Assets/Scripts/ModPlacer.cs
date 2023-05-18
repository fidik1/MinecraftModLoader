using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        for (int i = 0; i < _mods.Count; i++)
        {
            ModContent mod = Instantiate(_modPrefab, _modsHolder);
            mod.Init(_mods[i]);
            mod.Interacted += OnInteract;
        }
    }

    private void OnInteract(Mod mod)
    {
        _screenController.OpenScreen(4);
        _modView.OpenMod(mod);
    }
}
