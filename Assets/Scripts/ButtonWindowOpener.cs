using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonWindowOpener : MonoBehaviour
{
    [SerializeField] private WindowIdentifier _ID;
    
    public void Open() => ScreenController.GetInstance().OpenScreen(_ID);
}
