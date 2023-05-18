using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Mod", menuName="Mod")]
public class Mod : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField] public Sprite[] ScreenShots { get; private set; }
    [field: SerializeField] public string DescriptionID { get; private set; }
}
