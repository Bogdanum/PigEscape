using UnityEngine;

public class PigHealth : Singleton<PigHealth>
{
    private int HEALTH = 3;

    public void RemoveHeart()
    {
        UserInterface.Instance.RemoveHeart();

        if (HEALTH == 1) Dead();
        else
            HEALTH--;
    }

    public void AddHeart()
    {
        if (HEALTH == 3) return;
        else
        {
            HEALTH++;
            UserInterface.Instance.AddHeart();
        }
    }

    private void Dead()
    {
        AudioPlayer.Instance.LowerVolume();
        UserInterface.Instance.ShowRestartView();
        Destroy(gameObject);
    }

    public void SubscribeEnemyAttack(EnemyAttack weapon)
    {
        weapon.OnEnemyAttack += RemoveHeart;
    }

    public void UnsubscribeEnemyAttack(EnemyAttack weapon)
    {
        weapon.OnEnemyAttack -= RemoveHeart;
    }

    public void SubscribeBomb(Bomb bomb)
    {
        bomb.OnDetonateBomb += RemoveHeart;
    }

    public void UnsubscribeBomb(Bomb bomb)
    {
        bomb.OnDetonateBomb -= RemoveHeart;
    }
}
