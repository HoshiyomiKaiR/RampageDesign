using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateTreasureCountTxt : MonoBehaviour
{
    TextMeshProUGUI selfTxt_;

    void Start()
    {
        selfTxt_ = GetComponent<TextMeshProUGUI>();
    }

    public void SetTxtValue(string setValue_)
    {
        selfTxt_.text = "x " + setValue_;
    }
}
