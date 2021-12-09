using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(CircleCollider2D))]
public class Bomb : MonoBehaviour
{
    [SerializeField, Range(1, 10)]
    private float timeToExplosion = 2, damage = 1;

    [SerializeField] private GameObject explosion,
                                        explosionSound;

    public event Action OnDetonateBomb = default;

    public float Damage { get { return damage; } }

    private void Awake()
    {
        StartCoroutine(Boom());
    }

    private IEnumerator Boom()
    {
        yield return new WaitForSeconds(timeToExplosion);

        if (OnDetonateBomb != null)
        {
            OnDetonateBomb();
        }
        SpawnEffect(explosion);
        SpawnEffect(explosionSound);

        Destroy(gameObject);
    }

    private void SpawnEffect(GameObject effect)
    {
        Instantiate(effect, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger) return;

        switch (collision.gameObject.tag)
        {
            case "Pig":
                PigHealth.Instance.SubscribeBomb(this);
                break;
            case "Barrel":
                Barrel barrel = collision.gameObject.GetComponent<Barrel>();
                barrel.SubscribeBomb(this);
                break;
            case "Gardener":
                EnemyHealth gardener = collision.gameObject.GetComponent<EnemyHealth>();
                gardener.SubscribeBomb(this);
                break;
            case "Dog":
                EnemyHealth dog = collision.gameObject.GetComponent<EnemyHealth>();
                dog.SubscribeBomb(this);
                break;
            default: break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Pig":
                PigHealth.Instance.UnsubscribeBomb(this);
                break;
            case "Barrel":
                Barrel barrel = collision.gameObject.GetComponent<Barrel>();
                barrel.UnsubscribeBomb(this);
                break;
            case "Gardener":
                EnemyHealth gardener = collision.gameObject.GetComponent<EnemyHealth>();
                gardener.UnsubscribeBomb(this);
                break;
            case "Dog":
                EnemyHealth dog = collision.gameObject.GetComponent<EnemyHealth>();
                dog.UnsubscribeBomb(this);
                break;
            default: break;
        }
    }
}
