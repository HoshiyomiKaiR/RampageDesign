using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class ObjSceneLoader : MonoBehaviour
{
    [SerializeField] UnityEvent beforeStartLoad_;

    float delayLoadTime_ = 0;

    string sceneName_;

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
