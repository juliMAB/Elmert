using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFader : MonoBehaviour
{
    [SerializeField] private SpriteRenderer fader = null;
    [SerializeField] private float duration = 1;

    public void StartFader(bool fadeToBlack, Action callback)
    {
        IEnumerator Fade()
        {
            float time = 0;

            while (time < duration)
            {
                time += Time.deltaTime;
                Color color = Color.black;
                if (fadeToBlack)
                {
                    color.a = time / duration;
                }
                else
                {
                    color.a = 1 - time / duration;
                }
                
                fader.color = color;
                yield return null;
            }

            callback?.Invoke();
        }

        StartCoroutine(Fade());
    }
}
