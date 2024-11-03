using UnityEngine;
using UnityEngine.UI;

public class UIComboSystem : MonoBehaviour
{

    public Slider comboSlider;

   
    void Start()
    {
        comboSlider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (comboSlider.value < 100)
        {
            comboSlider.value++;
        }
        else 
        {
            comboSlider.value = 0;
        }

    }
}
