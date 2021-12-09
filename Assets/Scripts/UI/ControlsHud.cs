using UnityEngine;

public class ControlsHud : MonoBehaviour
{
    public void DisableMobileControls()
    {
        gameObject.SetActive(false);
    }

    public void ThrowBomb()
    {
        BombLauncher.Instance.ThrowBomb();
    }
}
