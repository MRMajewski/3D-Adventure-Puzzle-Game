using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;
    
    private Vector2 velocity;

    void FixedUpdate()
    {
        if (!Input.anyKey) return;

        velocity.y = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        velocity.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(velocity.x, 0, velocity.y);
    }

    public void SetPlayerSpeed(float speed)
    {
        this.speed = speed;
    }
}
