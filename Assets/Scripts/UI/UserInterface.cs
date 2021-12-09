using UnityEngine;

public class UserInterface : Singleton<UserInterface>
{
    [SerializeField, Space(10)] private HeartsUI heartsUI;
    [SerializeField]            private RestartViewUI restartView;
    [SerializeField]            private ControlsHud controlsHud;

    protected override void Awake()
    {
        base.Awake();
        InitUI();
    }

    private void InitUI()
    {
#if (!UNITY_ANDROID && !UNITY_IOS) || UNITY_EDITOR
        controlsHud.DisableMobileControls();
#endif
    }

    public void AddHeart()
    {
        heartsUI.AddHeart();
    }

    public void RemoveHeart()
    {
        heartsUI.RemoveHeart();
    }

    public void ShowRestartView()
    {
        restartView.ShowRestartHud();
    }

    public void ThrowBombButton()
    {
        BombLauncher.Instance.ThrowBomb();
    }
}
