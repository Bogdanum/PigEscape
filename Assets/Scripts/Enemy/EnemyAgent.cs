using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAgent : MonoBehaviour
{
    [SerializeField] private Transform[] targets;
    private NavMeshAgent agent;
    private EnemyHealth health;
    private Transform pig;

    private bool angry = false;
    private bool eventTrigger = true;
    private bool dead = false;

    private Vector2 _bufferTarget;

    private Vector2 RandomTarget
    {
        get {
            Vector2 randomPos = GetRandomTarget().position;
            _bufferTarget = randomPos;
            return randomPos;
        }
    }

    public bool isDead { get { return dead; } }

    public event System.Action OnAgentAngry = default;

    private void Awake()
    {        
        agent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();

        RefreshAgentProperties();
        Move(RandomTarget);

        health.OnDead += Dead;
    }

    private Transform GetRandomTarget()
    {
        Transform target = targets[Random.Range(0, targets.Length - 1)];
        return target;
    }

    private void RefreshAgentProperties()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        if (dead) return;

        if (Arrived() && !angry)
        {
            Move(RandomTarget);
        }
        else if (angry && pig != null)
        {
            Move(pig.transform.position);
            if (OnAgentAngry != null && eventTrigger)
            {
                OnAgentAngry();
            }
            
        }
    }

    private void Move(Vector2 target)
    {
        agent.SetDestination(target);
    }

    private void Dead()
    {
        dead = true;
        Move(transform.position);
        agent.velocity = Vector3.zero;
    }

    private bool Arrived()
    {
        return Vector2.Distance(transform.position, _bufferTarget) < 0.2f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Pig"))
        {
            pig = collision.transform;
            angry = true;
        }
    }
}
