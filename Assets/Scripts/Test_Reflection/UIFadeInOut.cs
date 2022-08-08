using System.Xml.Schema;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Reflection;

public class UIFadeInOut : MonoBehaviour
{
    public enum FadeState
    {
        None,
        FadeOut,
        ChangeBackground,
        FadeIn,
        Done
    }

    private FadeState _fadeState;

    private Image _backgroundImage;
    [SerializeField] Image _target;
    private IEnumerator _stateCroutine = null;

    private void Awake()
    {
        _backgroundImage = GetComponent<Image>();
        if (_backgroundImage == null)
        {
            Debug.LogWarning($"[UIFadeInOut] 이미지 없음");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (_fadeState == FadeState.None || _fadeState == FadeState.Done))
        {
            _fadeState = FadeState.None;
            NextState();
        }
    }

    protected void NextState()
    {
        MethodInfo info = GetType().GetMethod(_fadeState.ToString(), BindingFlags.Instance | BindingFlags.NonPublic);
        _stateCroutine = (IEnumerator)info.Invoke(this, null);
        StartCoroutine(RunState(_stateCroutine));
    }

    IEnumerator RunState(IEnumerator croutine)
    {
        yield return croutine;
        NextState();
    }

    IEnumerator None()
    {
        while (_fadeState == FadeState.None)
        {
            _fadeState = FadeState.FadeOut;
            yield return null;
        }
    }

    IEnumerator FadeOut()
    {
        float alpha = 0f;
        Color color = _backgroundImage.color;
        while (_fadeState == FadeState.FadeOut)
        {
            alpha += Time.deltaTime;
            color.a = alpha;
            _backgroundImage.color = color;
            if (alpha >= 1f)
            {
                _fadeState = FadeState.ChangeBackground;
                yield return null;
            }
            yield return null;
        }
    }

    IEnumerator ChangeBackground()
    {
        _target.color = Color.blue;
        _fadeState = FadeState.FadeIn;
        yield return null;
    }

    IEnumerator FadeIn()
    {
        float alpha = 1f;
        Color color = _backgroundImage.color;
        while (_fadeState == FadeState.FadeIn)
        {
            alpha -= Time.deltaTime;
            color.a = alpha;
            _backgroundImage.color = color;
            if (alpha <= 0f)
            {
                _fadeState = FadeState.Done;
                yield return null;
            }
            yield return null;
        }
    }

    IEnumerator Done()
    {
        while (_fadeState == FadeState.Done)
        {
            yield return null;
        }
    }
}
