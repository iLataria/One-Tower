using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIComboSystem : MonoBehaviour
{
    private float sliderCurrentWidth;
    private float sliderMinWidth = 30f;
    private float sliderMaxWidth = 250f;
    private float alphaChangeSpeed = 0.3f;
    private float leftLimit = 110f;
    private float rightLimit = 170f;
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
        Vector2 currentSize = sliderTransform.sizeDelta;
        currentSize.x++;
        sliderTransform.sizeDelta = currentSize;

        if (sliderTransform.sizeDelta.x >= sliderMaxWidth || Input.GetMouseButtonDown(0))
        {
            Debug.Log(currentSize.x);
            currentSize.x=sliderMinWidth;
            sliderTransform.sizeDelta = currentSize;

            //if (currentSize.x > leftLimit && currentSize.x<rightLimit) 
            //{
            //    Debug.Log("Nice");
            //    newSize.x = sliderMinWidth;
            //    sliderTransform.sizeDelta = newSize;

            //}
            //else
            //{
            //    newSize.x = 0;
            //    sliderTransform.sizeDelta = newSize;
            //}


        }

    }

    private IEnumerator AlphaChange()
    {
        yield return new WaitForSeconds(1);

        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha +=alphaChangeSpeed*Time.deltaTime;
            yield return null;
        }
       
        yield return new WaitForSeconds(2);

        if (sliderTransform != null)
        {
            Vector2 newSize = sliderTransform.sizeDelta;
            newSize.x = sliderMinWidth;
            yield return null;


            //while (newSize.x<sliderMaxWidth)
            //{
            //    newSize.x++;
            //    sliderTransform.sizeDelta = newSize;
            //    yield return null;
            //}
        }
      
    }
}
