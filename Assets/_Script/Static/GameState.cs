using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    static bool isPause = false;
    public static bool IsPause
    {
        get
        {
            return isPause;
        }
    }

    public static void SetTimeScale(float value)
    {
        Time.timeScale = value;
    }

    public static void QuitGame()
    {
        Application.Quit();
    }

    public static void PauseGame()
    {
        isPause = true;
        Time.timeScale = 0;
    }

    public static void ContinueGame()
    {
        isPause = false;
        Time.timeScale = 1;
    }
}
