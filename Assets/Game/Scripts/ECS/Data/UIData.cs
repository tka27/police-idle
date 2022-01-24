using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIData : MonoBehaviour
{
    public static UIData Instance { get; private set; }
    public FixedJoystick Joystick;

    private void Awake()
    {
        Instance = this;
    }
}
