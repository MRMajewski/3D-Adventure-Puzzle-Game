using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    [SerializeField]
     GroundCheck groundCheck;
     Rigidbody rigidbody;
    public float jumpStrength;
    public event System.Action Jumped;

    public PlayerStatistics playerStatistics;


    public float jumpForce;
    public float jumpMaxForce;

    public float jumpUnit;

    public UIManager UIManager;

    public AudioManager audio;


    void Reset()
    {
        groundCheck = GetComponentInChildren<GroundCheck>();
        if (!groundCheck)
            groundCheck = GroundCheck.Create(transform);
    }

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        playerStatistics.SetJumpPower(playerStatistics.PlayerJumpPower);

    }

    void LateUpdate()
    {
        //if (Input.GetButtonDown("Jump") && groundCheck.isGrounded)
        //{
        //    //   jumpStrength = playerStatistics.PlayerJumpPower;
        //    rigidbody.AddForce(Vector3.up * 100 * jumpStrength);
        //    Jumped?.Invoke();
        //}


        jumpMaxForce = playerStatistics.PlayerJumpPower;
        UIManager.JumpingUI(0, jumpMaxForce);

        if (Input.GetButton("Jump") && groundCheck.isGrounded)
        {


            UIManager.JumpingUI(0, jumpMaxForce);

            jumpForce += Time.deltaTime * jumpUnit;

            UIManager.JumpingUI(jumpForce, jumpMaxForce);

        }
        if (Input.GetButtonUp("Jump"))
        {
            audio.Play("Jump");
            UIManager.JumpingUI(0, jumpMaxForce);

            if (jumpForce >= jumpMaxForce) jumpForce = jumpMaxForce;

            Jump(jumpForce);
            jumpForce = 0;
        }
    }

    public void SetJumpPower(float jumpStrength)
    {
        this.jumpStrength = jumpStrength;
    }

    public void Jump(float jumpForce)
    {
            rigidbody.AddForce(Vector3.up * 100 * jumpForce);
            Jumped?.Invoke();
    }
}

