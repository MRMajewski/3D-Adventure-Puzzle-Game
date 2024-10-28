using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    [SerializeField]
    private GroundCheck groundCheck;
    [SerializeField]
    private Rigidbody rigidbody;
    public event System.Action Jumped;

    public PlayerStatistics playerStatistics;

    private float jumpForce;
    private float jumpMaxForce;
    [SerializeField]
    private float jumpUnit;

    [SerializeField]
    private UIManager UIManager;
    private void LateUpdate()
    {
        if (Input.GetButton("Jump") && groundCheck.isGrounded)
        {
            jumpForce += Time.deltaTime * jumpUnit;
            if (jumpForce > jumpMaxForce) 
                jumpForce = jumpMaxForce;

            UIManager.JumpingUI(jumpForce, jumpMaxForce);
        }

        else if (Input.GetButtonUp("Jump") && groundCheck.isGrounded)
        {
            AudioManager.Instance.Play("Jump");
            Jump(jumpForce);
            ResetJump();
        }
        else if(!groundCheck.isGrounded && jumpForce!=0)
        {
            ResetJump();
        }
    }

    public void ResetJump()
    {
        jumpForce = 0;
        UIManager.JumpingUI(jumpForce, jumpMaxForce); 
    }

    public void SetMaxJumpPower(float maxJumpPower)
    {
        this.jumpMaxForce = maxJumpPower;
    }

    public void Jump(float force)
    {
        rigidbody.AddForce(Vector3.up * force, ForceMode.Impulse);
        Jumped?.Invoke(); 
    }
}

