using UnityEngine;

public class EnemySounds : MonoBehaviour
{
    [SerializeField] private GameObject deadSoundEffect;

    private EnemyHealth health;

    private void Awake()
    {
        health = GetComponent<EnemyHealth>();
        health.OnDead += PlayDeadSound;
    }

    private void OnDestroy() => health.OnDead -= PlayDeadSound;

    private void PlayDeadSound()
    {
        Instantiate(deadSoundEffect, transform);
    }
}
