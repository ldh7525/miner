using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public enum TurnState
{
    Mining,
    Shop
}

public class SceneTransitionManager : PersistentSingleton<SceneTransitionManager>
{
    //[SerializeField] private CanvasGroup fadeOverlayCanvas; // canvas space - camera ,  overlayCamera에만 보임
    [SerializeField] private CanvasGroup fadeCanvas; // canvas space - overlay
    [SerializeField] private float fadeDuration;

    public event Action OnMiningTurnEnter;
    public event Action OnShopTurnEnter;
    private TurnState currentTurnState;

    private void ChangeTurn()
    {
        if (currentTurnState == TurnState.Mining)
        {
            // 씬 변경 등
            currentTurnState = TurnState.Shop;
            OnShopTurnEnter?.Invoke();
        }
        else if (currentTurnState == TurnState.Shop)
        {
            currentTurnState = TurnState.Mining;
            OnMiningTurnEnter?.Invoke();
        }
    }


    protected override void Awake()
    {
        base.Awake();
    }

    // TODO: PendingLoad: 아마 예전에 씬전환후 데이터 넣어주는 용도였던거같은데, 구조 수정해야 할듯.
    public void StartTransition(string sceneName)
    {
        StartCoroutine(TransitionCoroutine(sceneName));
    }

    public IEnumerator TransitionCoroutine(string sceneName)
    {
        yield return FadeOutRealtime();


        ChangeTurn(); // 이벤트 등

        // 기다리기 
        AsyncOperation load = SceneManager.LoadSceneAsync(sceneName);
        while (load != null && !load.isDone)
        {
            yield return null;
        }


        yield return FadeInRealtime();
    }


    #region Fade 모음
    //어두워짐
    //public IEnumerator OverlayFadeOut()
    //{
    //    // 0f에서 시작
    //    fadeOverlayCanvas.DOFade(1f, fadeDuration).SetEase(Ease.Linear).SetUpdate(true);
    //    yield return new WaitForSeconds(fadeDuration);
    //}

    //// 밝아짐
    //public IEnumerator OverlayFadeIn()
    //{
    //    // 1f에서 시작
    //    fadeOverlayCanvas.DOFade(0f, fadeDuration).SetEase(Ease.Linear).SetUpdate(true);
    //    yield return new WaitForSeconds(fadeDuration);
    //}

    // 밝아짐
    public IEnumerator FadeIn()
    {
        // 0f에서 시작
        fadeCanvas.DOFade(0f, fadeDuration).SetEase(Ease.Linear).SetUpdate(true);
        fadeCanvas.blocksRaycasts = true;
        yield return new WaitForSeconds(fadeDuration);
    }

    public IEnumerator FadeOut()
    {
        // 1f에서 시작
        fadeCanvas.DOFade(1f, fadeDuration).SetEase(Ease.Linear).SetUpdate(true);
        fadeCanvas.blocksRaycasts = false;
        yield return new WaitForSeconds(fadeDuration);
    }

    //public IEnumerator TransitionWithFade(string sceneName)
    //{
    //    yield return OverlayFadeIn();
    //    yield return TransitionCoroutine(sceneName);
    //    yield return OverlayFadeOut();
    //}

    public IEnumerator FadeOutRealtime()
    {
        // 0f에서 시작
        fadeCanvas.DOFade(1f, fadeDuration).SetEase(Ease.Linear).SetUpdate(true);
        yield return new WaitForSecondsRealtime(fadeDuration);
    }

    public IEnumerator FadeInRealtime()
    {
        // 1f에서 시작
        fadeCanvas.DOFade(0f, fadeDuration).SetEase(Ease.Linear).SetUpdate(true);
        yield return new WaitForSecondsRealtime(fadeDuration);
    }

    #endregion

}
