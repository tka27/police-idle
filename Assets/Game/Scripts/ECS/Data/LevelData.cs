using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    public static LevelData Instance { get; private set; }
    public GameObject Player;

    private void Awake()
    {
        Instance = this;
    }
}
