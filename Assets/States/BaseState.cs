using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    public virtual void Entry()
    {
        Debug.Log($"Entry {ToString()}");
    }

    public virtual void Update()
    {
        Debug.Log($"Update {ToString()}");
    }

    public virtual void Exit()
    {
        Debug.Log($"Exit {ToString()}");
    }
}
