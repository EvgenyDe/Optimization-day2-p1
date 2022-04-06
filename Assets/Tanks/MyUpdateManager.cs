using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpdateble
{
    void Tik();
}
public class MyUpdateManager : MonoBehaviour
{
    public IUpdateble[] updatebles;

    private static int nextUpdatable;
    // Start is called before the first frame update
    void Start()
    {
        updatebles = new IUpdateble[1000];
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var _updateble in updatebles)
        {
            if (_updateble != null)
            {
                _updateble.Tik();
            }
        }
    }

    public void AddUpdatable(IUpdateble iUpdateble)
    {
        for (int i = 0; i < updatebles.Length; i++)
        {
            if (updatebles[i] == null)
            {
                updatebles[i] = iUpdateble;
                return;
            }
        }

        var lenth = updatebles.Length;
        IUpdateble[] newArray = new IUpdateble[lenth * 2];
        for (int i = 0; i < updatebles.Length; i++)
        {
            newArray[i]=updatebles[i];
        }

        updatebles = newArray;
    }
    
    public void RemoveUpdatable(IUpdateble iUpdatebles)
    {
        for (int i = 0; i < updatebles.Length; i++)
        {
            if (updatebles[i] == iUpdatebles)
            {
                updatebles[i] = null;
                return;
            }
        }
    }
}
