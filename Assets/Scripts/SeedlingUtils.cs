using Seedling.Managers;
using UnityEngine;

public static class SeedlingUtils
{
    public static void Enable(this CanvasGroup cg)
    {
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }

    public static void Disable(this CanvasGroup cg)
    {
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }

    public static void FadeOutCanvas(this CanvasGroup cg)
    {
        FunctionUpdater.InitIfNeeded();

        FunctionUpdater.Create(delegate ()
        {
            cg.alpha -= NotificationManager.Instance.NotificationFadeTime * Time.unscaledDeltaTime;

            if (cg.alpha <= 0f)
            {
                cg.blocksRaycasts = false;
                cg.interactable = false;
                cg.alpha = 0f;
                return true;
            }
            else return false;
        }, "CanvasFadeOut");
    }

    public static void FadeOutCanvas(this CanvasGroup cg, float waitTime)
    {
        FunctionUpdater.InitIfNeeded();

        FunctionUpdater.Create(delegate ()
        {
            cg.alpha -= NotificationManager.Instance.NotificationFadeTime * Time.unscaledDeltaTime;

            if (Time.unscaledDeltaTime <= waitTime) return false;

            if (cg.alpha <= 0f)
            {
                cg.blocksRaycasts = false;
                cg.interactable = false;
                cg.alpha = 0f;
                return true;
            }
            else return false;
        }, "CanvasFadeOut");
    }

    public static void FadeInCanvas(this CanvasGroup cg, float waitTime)
    {
        FunctionUpdater.InitIfNeeded();

        FunctionUpdater.Create(delegate ()
        {
            cg.alpha += NotificationManager.Instance.NotificationFadeTime * Time.unscaledDeltaTime;

            if (Time.unscaledDeltaTime <= waitTime) return false;

            if (cg.alpha <= 1f)
            {
                cg.blocksRaycasts = true;
                cg.interactable = true;
                cg.alpha = 1f;
                return true;
            }
            else return false;
        }, "CanvasFadeIn");
    }

    public static void FadeInCanvas(this CanvasGroup cg)
    {
        FunctionUpdater.InitIfNeeded();

        FunctionUpdater.Create(delegate ()
        {
            cg.alpha += NotificationManager.Instance.NotificationFadeTime * Time.unscaledDeltaTime;

            if (cg.alpha <= 1f)
            {
                cg.blocksRaycasts = true;
                cg.interactable = true;
                cg.alpha = 1f;
                return true;
            }
            else return false;
        }, "CanvasFadeIn");
    }
}
