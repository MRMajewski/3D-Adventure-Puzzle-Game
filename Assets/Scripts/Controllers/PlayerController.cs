using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; } // Static instance for Singleton

    [SerializeField]
    private PlayerStatistics playerStatistics; 
    [SerializeField]
    private JumpScript jumpScript;
    [SerializeField]
    private FirstPersonMovement playerMovement;

    public PlayerStatistics PlayerStatistics { get { return playerStatistics; } }
    public JumpScript JumpScript { get { return jumpScript; } }
    public FirstPersonMovement FirstPersonMovement { get { return playerMovement; } set { } }

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

        playerStatistics.InitPlayerStatistics();
    }
}
