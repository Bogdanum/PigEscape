using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PigStateMachine : MonoBehaviour
{
    Animator animator;

    private void Awake() => animator = GetComponent<Animator>();

    public void Horizontal(float axis)
    {
        animator.SetFloat("Horizontal", axis);
    }

    public void Vertical(float axis)
    {
        animator.SetFloat("Vertical", axis);
    }
}
