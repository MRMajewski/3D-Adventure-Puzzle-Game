using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerStatistics : MonoBehaviour
{
    [SerializeField]
    private float playerThrowPower=0;
    [SerializeField]
    private float playerJumpPower=0;
    [SerializeField]
    private float playerMovementSpeed=2;

    public float PlayerThrowPower { get => playerThrowPower; }
    public float PlayerJumpPower  { get => playerJumpPower; }
    public float PlayerMovementSpeed { get => playerMovementSpeed; }

    public void InitPlayerStatistics()
    {
        PlayerController.Instance.JumpScript.SetJumpPower(this.playerJumpPower);
        PlayerController.Instance.FirstPersonMovement.SetPlayerSpeed(this.playerMovementSpeed);
    }

    public void SetThrowPower(float power)
    {
        playerThrowPower += power;
    }

    public void SetJumpPower(float power)
    {
        playerJumpPower += power;
        PlayerController.Instance.JumpScript.SetJumpPower(this.playerJumpPower);
    }

    public void SetRunPower(float power)
    {
        playerMovementSpeed += power;
        PlayerController.Instance.FirstPersonMovement.SetPlayerSpeed(this.playerMovementSpeed);
    }

}
