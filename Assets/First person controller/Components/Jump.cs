using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField]
     GroundCheck groundCheck;
     Rigidbody rigidbody;
    public float jumpStrength;
    public event System.Action Jumped;

  //  public PlayerStatistics playerStatistics;


    void Reset()
    {
        groundCheck = GetComponentInChildren<GroundCheck>();
        if (!groundCheck)
            groundCheck = GroundCheck.Create(transform);
    }

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
      //  playerStatistics.SetJumpPower(playerStatistics.PlayerJumpPower);
        
    }

    void LateUpdate()
    {
        if (Input.GetButtonDown("Jump") && groundCheck.isGrounded)
        {
            rigidbody.AddForce(Vector3.up * 100 * jumpStrength);
            Jumped?.Invoke();
        }
    }

    public void SetJumpPower(float jumpStrength)
    {
        this.jumpStrength = jumpStrength;
    }
}
