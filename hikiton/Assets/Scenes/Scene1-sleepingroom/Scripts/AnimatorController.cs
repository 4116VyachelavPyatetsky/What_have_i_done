using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class AnimatorController : MonoBehaviour
{
    private TextMeshProUGUI message;
    private float betweenhalf = 0.05f;
    private float betweenChar = 0.03f;
    private float smoothTime = 0.1f;

    private List<float> leftalphas;
    private List<float> rightalphas;

    private void SwitchColor()
    {
        for (int i = 0; i < leftalphas.Count; i++)
        {
            if (message.textInfo.characterInfo[i].character != '\n' &&
                message.textInfo.characterInfo[i].character != ' ')
            {
                int meshIndex = message.textInfo.characterInfo[i].materialReferenceIndex;
                int vertexIndex = message.textInfo.characterInfo[i].vertexIndex;

                Color32[] vertexColors = message.textInfo.meshInfo[meshIndex].colors32;

                vertexColors[vertexIndex + 0].a = (byte)leftalphas[i];
                vertexColors[vertexIndex + 1].a = (byte)leftalphas[i];
                vertexColors[vertexIndex + 2].a = (byte)rightalphas[i];
                vertexColors[vertexIndex + 3].a = (byte)rightalphas[i];
            }
        }
    }

    private IEnumerator Smooth(int i)
    {
        if(i>=leftalphas.Count)
            yield break;

        DOTween.To(
            
            () => leftalphas[i],
            x => leftalphas[i] = x,
            255,
            smoothTime)
            .SetEase(Ease.Linear)
            .SetId(i);
        yield return new WaitForSeconds(betweenhalf);

        DOTween.To(

            () => leftalphas[i],
            x => leftalphas[i] = x,
            255,
            smoothTime)
            .SetEase(Ease.Linear)
            .SetId(i);
        yield return new WaitForSeconds(betweenhalf);
    }
}
