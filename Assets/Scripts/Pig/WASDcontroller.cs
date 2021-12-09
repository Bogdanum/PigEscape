#if UNITY_EDITOR || UNITY_STANDALONE
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class WASDcontroller : MonoBehaviour
{
    [SerializeField, Range(1, 10)]
    private float speed = 1;

    private Rigidbody2D pigRB;
    private PigStateMachine pigStateMachine;
    private BombLauncher bombLauncher;

    private void Awake()
    {
        pigRB = GetComponent<Rigidbody2D>();
        pigStateMachine = GetComponent<PigStateMachine>();
        bombLauncher = GetComponent<BombLauncher>();
    }

    private void FixedUpdate()
    {
        Move();

        if (GetFireCommand())
        {
            bombLauncher.ThrowBomb();
        }
    }

    private void Move()
    {
        float horizontalForce = Input.GetAxis("Horizontal");
        float verticalForce = Input.GetAxis("Vertical");

        pigStateMachine.Horizontal(horizontalForce);
        pigStateMachine.Vertical(verticalForce);

        pigRB.velocity = new Vector2(horizontalForce, verticalForce) * speed;
    }

    private bool GetFireCommand()
    {
        return Input.GetButton("Fire1") || Input.GetButton("Jump");
    }
}

#endif