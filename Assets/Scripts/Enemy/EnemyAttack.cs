using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private EnemyAgent agent;
    [SerializeField]
    private float reloadTime = 1;
    
    private float nextShotTime = 0;

    public event Action OnEnemyAttack = default;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (agent.isDead) return;

        if (collision.tag == "Pig")
        {
            if (OnEnemyAttack == null)
                PigHealth.Instance.SubscribeEnemyAttack(this);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Pig")
        {
            PigHealth.Instance.UnsubscribeEnemyAttack(this);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (agent.isDead) return;

        if (collision.tag == "Pig")
        {
            if (Time.time > nextShotTime)
            {
                if (OnEnemyAttack != null)
                {
                    OnEnemyAttack();
                }
                nextShotTime = Time.time + reloadTime;
            }
        }
    }
}
