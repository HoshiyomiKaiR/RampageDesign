using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TreasureCheck : MonoBehaviour
{
    [SerializeField] GameObject gameClearCanvas_;

    [SerializeField] AudioSource gameOverSE_;

    [SerializeField] TreasurePack playerTreasurePack_;
    [SerializeField] byte treasureSum_;
    [SerializeField] float gameOverDelayTime_;

    RocketLiftOff selfRocketLiftOff_;
    ObjSceneLoader selfObjSceneLoader_;

    void Start()
    {
        selfRocketLiftOff_ = GetComponent<RocketLiftOff>();
        selfObjSceneLoader_ = GetComponent<ObjSceneLoader>();

        selfRocketLiftOff_.LiftOffEvent += check;
    }

    void check(object sender, EventArgs eventArgs)
    {
        print(this + ".check Call by " + sender);

        if (playerTreasurePack_.TreasureCount < treasureSum_)
        {
            gameOverSE_.Play();

            selfObjSceneLoader_.SetDelayLoadTime(gameOverDelayTime_);
            selfObjSceneLoader_.LoadScene("GameScene");
        }
        else
        {
            gameClearCanvas_.SetActive(true);
        }
    }
}
