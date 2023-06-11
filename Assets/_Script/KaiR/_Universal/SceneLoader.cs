using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] UnityEvent sceneAwake_;
    [SerializeField] UnityEvent beforeStartLoad_;

    [SerializeField] bool hideCursor_;

    float delayLoadTime_ = 0;

    string sceneName_;

    void Awake()
    {
        //ObjPool.ClearPool();
        GameState.ContinueGame();
        sceneAwake_.Invoke();
        if (hideCursor_)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void SetDelayLoadTime(float delayTime_)
    {
        delayLoadTime_ = delayTime_;
    }

    public void LoadScene(string name_)
    {
        sceneName_ = name_;
        StartCoroutine(nameof(AsyncLoadScene));
    }
    IEnumerator AsyncLoadScene()
    {
        float waitDuration_ = 0;
        while (waitDuration_ < delayLoadTime_)
        {
            waitDuration_ += Time.unscaledDeltaTime;
            yield return null;
        }

        beforeStartLoad_.Invoke();
        GameState.PauseGame();

        AsyncOperation asyncLoad_ = SceneManager.LoadSceneAsync(sceneName_);

        while (!asyncLoad_.isDone)
        {
            yield return null;
        }
    }
}
