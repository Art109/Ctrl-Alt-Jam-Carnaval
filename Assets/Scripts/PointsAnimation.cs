using TMPro;
using UnityEngine;
using DG.Tweening;

public class PointsAnimation : MonoBehaviour
{
    public float points = 300;
    public TextMeshProUGUI textPoints;

    public float animationDuration = 3f;

    private int lastDisplayedPoints = -1; // Armazena o �ltimo valor mostrado

    void Start()
    {
        AnimatePoints();
    }

    void AnimatePoints()
    {
        float currentPoints = 0;

        DOTween.To(() => currentPoints, x =>
        {
            currentPoints = x;
            int roundedPoints = Mathf.FloorToInt(currentPoints);

            // S� atualiza o texto e chama a anima��o se o n�mero realmente mudou
            if (roundedPoints != lastDisplayedPoints)
            {
                textPoints.text = roundedPoints.ToString();
                AnimateScale();
                lastDisplayedPoints = roundedPoints; // Atualiza o �ltimo valor mostrado
            }
        }, points, animationDuration)
        .SetEase(Ease.OutQuad);
    }

    void AnimateScale()
    {
        textPoints.transform.DOScale(1.3f, 0.1f)
            .SetEase(Ease.OutQuad)
            .OnComplete(() => textPoints.transform.DOScale(1f, 0.1f));
    }
}
