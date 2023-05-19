using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameScreen : MonoBehaviour
{
    public abstract WindowIdentifier ID { get; }
    public abstract int Value { get; }
}

public enum WindowIdentifier
{
    Main,
    Mods,
    ModView,
    ModLoader,
    Instruction,
    PrivacyPolicy
}