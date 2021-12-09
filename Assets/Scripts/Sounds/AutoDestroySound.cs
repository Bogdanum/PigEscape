using UnityEngine;
using System.Collections;

public class AutoDestroySound : MonoBehaviour
{
    [SerializeField, Range(1, 100)]
    private float timeToDestroy = 2;

    private void Awake()
    {
        StartCoroutine(DestroyAfterSound());
    }

    private IEnumerator DestroyAfterSound()
    {
        yield return new WaitForSeconds(timeToDestroy);

        Destroy(gameObject);
    }
}
