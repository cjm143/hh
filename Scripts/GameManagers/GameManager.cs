using System.Collections.Generic;
using System.Linq;
using com.kleberswf.lib.core;

public class GameManager : Singleton<GameManager>
{
    public List<InitStarter> inits { get; private set; } = new();

    public void AddInitStarter(InitStarter init)
    {
        if (init == null)
            return;

        inits.Add(init);
    }


    private void Start()
    {
        inits.OrderBy(init => init.Priority);

        foreach (InitStarter init in inits)
        {
            init.Init();
        }
    }

    public T GetStarter<T>() where T : InitStarter
    {
        var tempStarter = inits.Find(x => x as T);
        if (tempStarter is T)
        {
            return tempStarter as T;
        }
        return null;
    }
}
