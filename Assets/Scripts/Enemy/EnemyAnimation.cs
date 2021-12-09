using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator), typeof(NavMeshAgent), typeof(EnemyHealth))]
public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private string AngryAnimatorName,
                                    DirtyAnimatorName;

    private Animator animator;
    private NavMeshAgent agent;
    private EnemyAgent enemy;
    private EnemyHealth health;
    private bool angryTrigger = true;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        enemy = GetComponent<EnemyAgent>();
        health = GetComponent<EnemyHealth>();

        enemy.OnAgentAngry += SelectAngryAnimation;
        health.OnDead += SelectDirtyAnimation;
    }

    private void OnDestroy()
    {
        enemy.OnAgentAngry -= SelectAngryAnimation;
        health.OnDead -= SelectDirtyAnimation;
    }

    private void SelectAngryAnimation()
    {
        if (angryTrigger)
        {
            LoadAnimatorController(AngryAnimatorName);
            angryTrigger = false;
        }
    }

    private void SelectDirtyAnimation()
    {
        LoadAnimatorController(DirtyAnimatorName);   
    }

    private void LoadAnimatorController(string name)
    {
        animator.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load(name);
    }

    private void Update()
    {
        SwicthAnimationDirection();
    }

    private void SwicthAnimationDirection()
    {
        if (agent.velocity.x == 0)
        {
            SetDirection(0);
        }
        else if
         (agent.velocity.y > .5f)
        {
            SetDirection(1);
        }
        else if
         (agent.velocity.y < -.5f)
        {
            SetDirection(2);
        }
        else if
         (agent.velocity.x > .5f)
        {
            SetDirection(3);
        }
        else if
         (agent.velocity.x < -.5f)
        {
            SetDirection(4);
        }
    }

    private void SetDirection(int direction)
    {
        animator.SetInteger("Direction", direction);
    }
}

