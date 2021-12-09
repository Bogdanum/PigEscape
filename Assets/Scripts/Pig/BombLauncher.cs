using UnityEngine;

public class BombLauncher : Singleton<BombLauncher>
{
    [SerializeField, Space(10)] private UnityEngine.Transform bombSpawnPoint,
                                       gameField;
    [SerializeField] private GameObject bomb;

    [SerializeField, Range(0.1f, 3)] private float Delay = 1;

    private PigSounds pigSounds;
    float nextShotTime;

    protected override void Awake()
    {
        base.Awake();
        pigSounds = GetComponent<PigSounds>();
    }

    public void ThrowBomb()
    {
        if (Time.time > nextShotTime)
        {
            Instantiate(bomb, bombSpawnPoint.position, Quaternion.identity, gameField);
            pigSounds.PutBombSound();
            nextShotTime = Time.time + Delay;
        }
    }
}
