using AloneTower.Towers;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace AloneTower.Modules
{
    public class ComboModule : MonoBehaviour
    {
        [SerializeField] private Image _comboFill;
        [SerializeField] private Tower _tower;

        private float _comboValue;

        public float ComboValue
        {
            get => _comboValue;
            
            set
            {
                _comboValue = value;
                _comboFill.fillAmount = _comboValue;

                if (_comboValue >= 1f)
                    StartCoroutine(OnComboStart());
            }
        }

        private IEnumerator OnComboStart()
        {
            Time.timeScale = .1f;
            
            yield return null;
        }
    }
}

