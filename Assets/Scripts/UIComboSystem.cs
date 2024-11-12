using UnityEngine;
using UnityEngine.UI;

public class UIComboSystem : MonoBehaviour
{
    private float sliderCurrentWidth;
    private float sliderMinWidth = 30f;
    private float sliderMaxWidth = 250f;

    [SerializeField]
    private RectTransform sliderTransform;
    private void Start()
    {
        if ( sliderTransform!= null)
        {
            Vector2 newSize = sliderTransform.sizeDelta;
            newSize.x = sliderMinWidth;
            sliderTransform.sizeDelta = newSize;
        }

    }
    private void Update()
    {
        
            Vector2 newSize = sliderTransform.sizeDelta;
            newSize.x++;
            sliderTransform.sizeDelta = newSize;

            if (sliderTransform.sizeDelta.x >= sliderMaxWidth)
            {
                newSize.x = sliderMinWidth;
                sliderTransform.sizeDelta = newSize;
            }
        
    }
}
