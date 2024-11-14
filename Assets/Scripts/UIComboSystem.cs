using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIComboSystem : MonoBehaviour
{
    private float sliderCurrentWidth;
    private float sliderMinWidth = 30f;
    private float sliderMaxWidth = 250f;

    [SerializeField]
    private RectTransform sliderTransform;
    [SerializeField]
    private CanvasGroup canvasGroup;
    private void Start()
    {
        canvasGroup.alpha = 0f;
        StartCoroutine(AlphaChange());
       
    }
    private void Update()
    {

        Vector2 newSize = sliderTransform.sizeDelta;
        newSize.x++;
        sliderTransform.sizeDelta = newSize;

        if (sliderTransform.sizeDelta.x >= sliderMaxWidth || Input.GetMouseButtonDown(0))
        {
            newSize.x = sliderMinWidth;
            sliderTransform.sizeDelta = newSize;
        }

    }

    private IEnumerator AlphaChange()
    {
        yield return new WaitForSeconds(2);

        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha +=0.1f;

        }
        
        if (sliderTransform != null)
        {
            Vector2 newSize = sliderTransform.sizeDelta;
            newSize.x = sliderMinWidth;
            sliderTransform.sizeDelta = newSize;
        }
      
    }
}
