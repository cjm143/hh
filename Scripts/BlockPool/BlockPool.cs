using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class BlockPool : InitStarter
{
    [SerializeField]
    private Dictionary<GameObject, int> prefabCounts = new Dictionary<GameObject, int>(); 


    public void OnPrefabDestroyed(GameObject block)
    {
        if (prefabCounts.ContainsKey(block))
        {
            prefabCounts[block]--;



            if (prefabCounts[block] < 0)
            {
                prefabCounts[block] = 0;

                CheckPrefabDepletion();
            }
        }
    }

    // prefab 대신 block과 같은 피쳐 용어 사용
    void CheckPrefabDepletion()
    {
        foreach (var count in prefabCounts.Values)
        {
            if (count > 0)
                return;
        }

        Debug.Log("Prefab Count 0");
    }


}
