using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class Language : MonoBehaviour
{
    private void Start()
    {
        SetLanguage();
    }

    public IEnumerator IELanguage(int i = 0)
    {
        // Wait for the localization system to initialize, loading Locales, preloading, etc.
        yield return LocalizationSettings.InitializationOperation;

        // This part changes the language
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[i];
    }

    public void SetLanguage(int i = 0)
    {
        StartCoroutine(IELanguage(i));
    }
}
