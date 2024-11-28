using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIComboSystem : MonoBehaviour
{
    
    private float bonus = 1f;
    private float slowTimeScale = 0.2f;
    private float sliderMinWidth = 30f;
    private float sliderMaxWidth = 250f;
    private float alphaChangeSpeed = 3f;
    private float leftLimit = 110f;
    private float rightLimit = 170f;
    private Vector2 sliderSize;
    private Vector3 floatingTextOffset= new Vector3 (90,30,0);

    [SerializeField]
    private RectTransform sliderTransform;

    [SerializeField]
    private CanvasGroup canvasGroup;

    [SerializeField]
    private GameObject floatingTextPrefab;
    private void Start()
    {
        canvasGroup.alpha = 0f;
        
       
    }

    private void OnMouseDown()
    {
        StartCoroutine(ComboCoroutine());
        
    }
    private void SLowDownTime()
    {

        Time.timeScale = slowTimeScale;

    }
    private void SpeedUpTime()
    {

        Time.timeScale = 1f;

    }

    private void ShowFloatingText()
    {
       Instantiate(floatingTextPrefab,transform.position+floatingTextOffset,Quaternion.identity);
    }

    private IEnumerator ComboCoroutine()
    {
        sliderSize = sliderTransform.sizeDelta;
        sliderSize.x = sliderMinWidth;
        sliderTransform.sizeDelta = sliderSize;

        SLowDownTime();

        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha +=alphaChangeSpeed*Time.deltaTime;
            yield return null;
        }
       
        yield return new WaitForSeconds(0.5f);

        if(floatingTextPrefab !=null)
        {
            ShowFloatingText();
        }

        if (sliderTransform != null)
        {
            while (sliderSize.x < sliderMaxWidth)
            {
                //
                sliderSize.x+=bonus/2;
                yield return null;
                sliderTransform.sizeDelta = sliderSize;

                if (sliderSize.x >= sliderMaxWidth)
                {
                    sliderSize.x = sliderMinWidth;
                    yield return null;
                    sliderTransform.sizeDelta = sliderSize;

                }

                if (Input.GetMouseButtonDown(0) && (sliderSize.x <=rightLimit)&&(sliderSize.x>=leftLimit))
                {
                    sliderSize.x = sliderMinWidth;
                    yield return null;
                    sliderTransform.sizeDelta = sliderSize;
                    bonus++;
                    Debug.Log(bonus);
                }
                else if (Input.GetMouseButtonDown(0))
                {
                    sliderTransform.sizeDelta = sliderSize;

                    while (canvasGroup.alpha >0)
                    {
                        canvasGroup.alpha -= alphaChangeSpeed * Time.deltaTime;
                        yield return null;
                    }
                    SpeedUpTime();
                }
                

            }
        }

    }
}
