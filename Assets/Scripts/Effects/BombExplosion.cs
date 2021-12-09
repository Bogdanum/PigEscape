using UnityEngine;
using System.Collections;

public class BombExplosion : MonoBehaviour
{
    [SerializeField, Range(1, 10)] private int timeToDestroy = 3;

    private void Start()
    {
        StartCoroutine(DestroyWithDelay(timeToDestroy));
    }

    private IEnumerator DestroyWithDelay(int delay)
    {
        yield return new WaitForSeconds(delay);

        Destroy(gameObject);
    }
}