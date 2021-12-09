#if UNITY_ANDROID || UNITY_IOS
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class JoystickController : MonoBehaviour
{
    [SerializeField]
    private SimpleTouchController joystick;

    [SerializeField, Range(0.1f, 10)]
    private float speed = 1;

    private Rigidbody2D pigRB;
    private PigStateMachine pigStateMachine;

    private void Awake()
    {
        pigRB = GetComponent<Rigidbody2D>();
        pigStateMachine = GetComponent<PigStateMachine>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 movementVector = joystick.GetTouchPosition;
        Vector2 normalizedVector = GetNormalizedVector(movementVector);

        pigStateMachine.Horizontal(normalizedVector.x);
        pigStateMachine.Vertical(normalizedVector.y);

        pigRB.velocity = movementVector * speed;
    }

    private Vector2 GetNormalizedVector(Vector2 vector)
    {
        if (Mathf.Abs(vector.x) > Mathf.Abs(vector.y))
            return new Vector2(vector.x, 0);
        else
            return new Vector2(0, vector.y);
    }
}
#endif
