using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ModContent : MonoBehaviour
{
    private Mod _mod;
    [field: SerializeField] public string Name { get; private set; }
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _name;

    public Action<Mod> Interacted;

    public void Init(Mod mod)
    {
        _mod = mod;
        Name = mod.Name;
        _name.text = Name;
        _icon.sprite = mod.Icon;
    }

    public void Interact()
    {
        Interacted?.Invoke(_mod);
    }
}
