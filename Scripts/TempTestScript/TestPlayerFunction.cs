public class TestPlayerFunction : InitChild
{

    public override void Init(InitStarter origin)
    {
        base.Init(origin);

        GameManager.Instance.GetStarter<TestPlayer>()?.GetChild<TestPlayerSpeak>()?.Speak();
    }
}
