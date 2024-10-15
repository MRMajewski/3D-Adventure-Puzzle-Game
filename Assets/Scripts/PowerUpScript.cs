using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    [SerializeField]
    private Interaction_PowerUp itemInteraction;
  //  private PlayerStatistics player;
   // private AudioManager audio;

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
        itemInteraction = FindObjectOfType<Interaction_PowerUp>();
    }

    public void PowerUpThrow(float value)
    {
        PlayerController.Instance.PlayerStatistics.SetThrowPower(value);
    }

    public void PowerUpJump(float value)
    {
        PlayerController.Instance.PlayerStatistics.SetJumpPower(value);
    }

    public void PowerUpRun(float value)
    {
        PlayerController.Instance.PlayerStatistics.SetRunPower(value);
    }

    private void OnMouseDown()
    {
        Debug.Log(itemInteraction.IsPowerUp);
        if (!itemInteraction.IsPowerUp) return;
        else
        {
            switch(powerUpType)
            {
                case PowerUpType.Throw:

                    PowerUpThrow(value);

                    break;

                case PowerUpType.Jump:

                    PowerUpJump(value);
  
                    break;

                case PowerUpType.Run:

                    PowerUpRun(value);
                    break;
            }
            AudioManager.Instance.Play("PickUpPowerUp");
            PickUpAnim();
            Destroy(this.gameObject,.9f);
        }
    }


    private void PickUpAnim()
    {
           LeanTween.moveLocalY(this.gameObject, 0.65f, 0.5f);

        LeanTween.sequence().
        append(LeanTween.rotateY(this.gameObject, 90f, 0.5f)).
        append(LeanTween.scale(this.gameObject, Vector3.zero, 0.4f));
    }
}
