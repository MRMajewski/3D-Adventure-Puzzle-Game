using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; } // Static instance for Singleton

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Init();
    }


    public void Init()
    {
      //  playerStatistics.SetJumpPower(playerStatistics.PlayerJumpPower);
    }
}
