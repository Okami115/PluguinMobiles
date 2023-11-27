using UnityEngine;
public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private PlayerController controller;
    [SerializeField] private PlayerConfig playerConfig;
    [SerializeField] private Animator animator;

    private Vector2 input;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D boxCollider;

    [SerializeField] private Joystick joystickLeft;

    void Start()
    {
        controller.playerMove += Move;
    }

    private void Move(Vector3 direction)
    {
        input = direction;
    }

    private void Update()
    {
        input.y = joystickLeft.Vertical;
        input.x = joystickLeft.Horizontal;

        if(input.x == 0 && input.y == 0) 
        {
            animator.SetInteger("Direction", 0);
        }


        rb.AddForce(playerConfig.Speed * input.normalized, ForceMode2D.Force);
    }
    private void LateUpdate()
    {
        if (input.x != 0 || input.y != 0)
        {
            animator.SetInteger("Direction", 1);
        }
    }
}
