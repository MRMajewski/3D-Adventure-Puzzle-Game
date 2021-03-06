using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatistics : MonoBehaviour
{

    public float PlayerThrowPower;
    public float PlayerJumpPower;
    public float PlayerMovementSpeed;

    public Jump jump;
    public FirstPersonMovement movement;

    public float SetThrowPower(float power)
    {
        PlayerThrowPower = power;
        return PlayerThrowPower;
    }

    public void SetJumpPower(float PlayerJumpPower)
    {
        jump.SetJumpPower(this.PlayerJumpPower);
    }

    public void SetRunPower(float PlayerMovementSpeed)
    {
        movement.SetPlayerSpeed(PlayerMovementSpeed);
    }

}
