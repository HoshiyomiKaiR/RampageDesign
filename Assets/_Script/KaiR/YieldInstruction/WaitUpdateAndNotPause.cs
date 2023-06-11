using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitUpdateAndNotPause : CustomYieldInstruction
{
    public override bool keepWaiting
    {
        get
        {
            return GameState.IsPause;
        }
    }
}
