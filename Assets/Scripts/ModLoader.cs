using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ModLoader : MonoBehaviour
{
    [SerializeField] private Mod _mod;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private ModView _modView;

    private void Start()
    {
        _modView.Interacted += LoadMod;
    }

    public void LoadMod(Mod mod)
    {
        _mod = mod;
        _name.text = mod.Name;
        LoadMod();
    }

    private void LoadMod()
    {
        print("LoadMod");
    }
}
