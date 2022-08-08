using System.Collections;
using System.Reflection;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILoading : MonoBehaviour
{
    public enum LoadingState
    {
        None,
        Unload,
        GotoScene,
        Done
    }

    private AsyncOperation _unloadDone, _loadLevelDont;
    private LoadingState _loadingState;
    private StringBuilder _stringBuilder;

    const float LOAD_LIMIT_TIME = 1.0f;
    
    private float _currentLoadingTime;

    private void Awake()
    {
        _stringBuilder = new StringBuilder();
    }

    private void Start()
    {
        _loadingState = LoadingState.None;
        NextState();
    }
    
    void NextState()
    {
        _stringBuilder.Remove(0, _stringBuilder.Length);
        _stringBuilder.Append(_loadingState.ToString());
        _stringBuilder.Append("State");

        MethodInfo method = this.GetType().GetMethod(_stringBuilder.ToString(), BindingFlags.NonPublic | BindingFlags.Instance);
        StartCoroutine(RunState((IEnumerator)method.Invoke(this, null)));
    }

    IEnumerator RunState(IEnumerator croutine)
    {
        yield return croutine;
        NextState();
    }

    IEnumerator NoneState()
    {
        while (_loadingState == LoadingState.None)
        {
            _loadingState = LoadingState.Unload;
            yield return null;
        }
    }

    IEnumerator UnloadState()
    {
        _unloadDone = Resources.UnloadUnusedAssets();
        System.GC.Collect();

        while (_loadingState == LoadingState.Unload)
        {
            if (_unloadDone.isDone)
            {
                _loadingState = LoadingState.GotoScene;
            }
            yield return null;
        }
    }

    IEnumerator GotoSceneState()
    {
        _currentLoadingTime = 0.0f;
        _loadLevelDont = SceneManager.LoadSceneAsync("MainScene");
        
        while (_loadingState == LoadingState.GotoScene)
        {
            _currentLoadingTime += Time.deltaTime;
            if (_loadLevelDont.isDone && _currentLoadingTime >= LOAD_LIMIT_TIME)
            {
                _loadingState = LoadingState.Done;
            }
            yield return null;
        }
    }

    IEnumerator DoneState()
    {
        while (_loadingState == LoadingState.Done)
        {
            _loadingState = LoadingState.None;
            yield return null;
        }
    }
}