using UnityEngine;
using System;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField, Range(1, 100)] private float HEALTH = 1;

    public event Action OnDead = default;

    public void SubscribeBomb(Bomb bomb)
    {
        bomb.OnDetonateBomb += DoDamage;
    }

    public void UnsubscribeBomb(Bomb bomb)
    {
        bomb.OnDetonateBomb -= DoDamage;
    }

    public void DoDamage()
    {
        if (HEALTH == 1)
        {
            if (HasSubscribers())
            {
                OnDead();
            }
            HEALTH--;
        }
        else
            HEALTH--;
    }

    private bool HasSubscribers()
    {
        return OnDead != null;
    }
}
