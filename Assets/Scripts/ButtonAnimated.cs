using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimated : MonoBehaviour
{
    public void OnHover(Transform thisTransform)
    {
        StartCoroutine(SmoothSizeChange(thisTransform, thisTransform.localScale.x, 1.1f));
    }
    public void OnExit(Transform thisTransform)
    {
        StartCoroutine(SmoothSizeChange(thisTransform, 1.1f, 1f));
    }

    private IEnumerator SmoothSizeChange(Transform buttonTransform, float startSize, float targetSize)
    {
        float currentScale;
        float timer = 0f;

        while (timer < 0.1f)
        {
            timer += Time.deltaTime;
            currentScale = Mathf.Lerp(startSize, targetSize, timer / 0.1f);
            buttonTransform.localScale = new Vector2(currentScale, currentScale);
            yield return null; // Wait for the next frame
        }

        buttonTransform.localScale = new Vector2(targetSize, targetSize);
    }
}
