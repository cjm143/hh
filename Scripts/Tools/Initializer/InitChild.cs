using UnityEngine;

public class InitChild : MonoBehaviour
{
    [SerializeField] protected int priority;
    public int Priority { get => priority; }

    protected InitStarter origin;

    public virtual void Init(InitStarter origin)
    {
        this.origin = origin;
    }
}
