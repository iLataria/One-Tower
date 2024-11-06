using UnityEngine;
using UnityEngine.UI;

namespace AloneTower
{
    public class UIComboSystem : MonoBehaviour
    {
        [SerializeField]
        private Slider comboSlider;
        [SerializeField]
        private float speed = 5.0f;
        void Start()
        {
            comboSlider.value = 0;
        }
        void Update()
        {
            if (comboSlider.value < 100)
            {
                comboSlider.value += speed;
            }
            else
            {
                comboSlider.value = 0;
            }

        }
    }
}

