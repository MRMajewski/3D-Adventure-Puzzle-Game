using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{

    private ItemInteraction itemInteraction;
    private PlayerStatistics player;

   // public TextMeshProUGUI panelText;


    [System.Serializable]
    public enum PowerUpType
    {
        Throw,
        Jump,
        Run
    }

    public PowerUpType powerUpType;

    [SerializeField]
    private float value;

    private void Awake()
    {
        itemInteraction = FindObjectOfType<ItemInteraction>();
        player = FindObjectOfType<PlayerStatistics>();
    }


    public void PowerUpThrow(float value)
    {
        player.PlayerThrowPower += value;
    }

    public void PowerUpJump(float value)
    {
         player.PlayerJumpPower += value;
        player.SetJumpPower(player.PlayerJumpPower );
    }

    public void PowerUpRun(float value)
    {
        player.PlayerMovementSpeed += value;
        player.SetRunPower(player.PlayerMovementSpeed);
    }

    private void OnMouseDown()
    {
        if (!itemInteraction.IsPowerUp) return;
        else
        {
            switch(powerUpType)
            {
                case PowerUpType.Throw:
                    PowerUpThrow(value);
                    Debug.Log("Widzi Throw");

                    break;

                case PowerUpType.Jump:

                    PowerUpJump(value);
                    Debug.Log("Widzi Jump");
  
                    break;

                case PowerUpType.Run:

                    PowerUpRun(value);
                    Debug.Log("Widzi Run");

                    break;
            }
            Destroy(this.gameObject);
        }
    }
}
