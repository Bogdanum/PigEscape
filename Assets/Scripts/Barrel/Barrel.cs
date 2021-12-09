using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class Barrel : MonoBehaviour
{
    [SerializeField, Range(.1f, 10)]
    private float timeToDestroy = .5f;

    [SerializeField]
    private GameObject woodSound;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SubscribeBomb(Bomb bomb)
    {
        bomb.OnDetonateBomb += DestroyBarrel;
    }

    public void UnsubscribeBomb(Bomb bomb)
    {
        bomb.OnDetonateBomb -= DestroyBarrel;
    }

    private void DestroyBarrel()
    {
        StartCoroutine(DestroyWithAnim(timeToDestroy));
    }

    private IEnumerator DestroyWithAnim(float delay)
    {
        animator.SetBool("Destr", true);
        Instantiate(woodSound, transform);

        yield return new WaitForSeconds(delay);

        Destroy(gameObject);
    }
}
