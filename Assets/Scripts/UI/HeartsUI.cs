using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartsUI : MonoBehaviour
{
    [SerializeField] private List<GameObject> heartsList;

    int currentHeartID = 2;

    public void AddHeart()
    {
        if (currentHeartID > 1) return;

        currentHeartID++;
        heartsList[currentHeartID].SetActive(true);
    }

    public void RemoveHeart()
    {
        if (currentHeartID < 0) return;

        heartsList[currentHeartID].SetActive(false);
        currentHeartID--;
    }
}
