using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : BaseManager
{
    public override string State
    {
        get { return _state;}
        set { _state = value; }
    }
    public override void Initialize()
    {
        _state = "Manager inicializado";
        Debug.Log(_state);
    }
}
