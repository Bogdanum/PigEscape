using UnityEngine;

public class PigSounds : MonoBehaviour
{
    [SerializeField] private GameObject putBombSound;

    public void PutBombSound()
    {
        Instantiate(putBombSound, transform);
    }
}
