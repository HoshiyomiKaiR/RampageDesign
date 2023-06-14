using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasurePack : MonoBehaviour
{
    [SerializeField] UpdateTreasureCountTxt updateTreasureCountTxt;

    byte treasureCount_ = 0;
    public byte TreasureCount
    {
        get
        {
            return treasureCount_;
        }
    }

    public void GetTreasure()
    {
        treasureCount_++;
        updateTreasureCountTxt.SetTxtValue(treasureCount_.ToString());
    }
}
