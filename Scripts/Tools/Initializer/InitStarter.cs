//For obj parent starts first initializing
//e.g. Player.cs, EnemySpawner.cs etc...
//Not for every scripts

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InitStarter : MonoBehaviour
{
    [SerializeField] protected int priority;
    public int Priority { get => priority; }

    private Dictionary<Type, InitChild> initChildDict;

    protected virtual void Awake()
    {
        var initChildren = GetComponentsInChildren<InitChild>();
        initChildren.OrderBy(child => child.Priority);
        initChildDict = initChildren.ToDictionary(child => child.GetType(), child => child);

        GameManager.Instance.AddInitStarter(this);
    }

    public virtual void Init()
    {
        foreach (var init in initChildDict.Values)
        {
            init.Init(this);
        }
    }

    // 특정 자식 클래스 가져오기 (T는 InitChild<InitStarter>를 상속받은 클래스)
    public T GetChild<T>() where T : InitChild
    {
        if (initChildDict.TryGetValue(typeof(T), out var child))
        {
            return child as T;
        }
        return null;
    }
}

