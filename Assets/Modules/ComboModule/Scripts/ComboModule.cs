using UnityEngine;
using UnityEngine.UI;

using AloneTower.Towers;
using System.Collections;

namespace AloneTower.Modules
{
    public class ComboModule : MonoBehaviour
    {
        [SerializeField] private Image _comboFill;
        [SerializeField] private Tower _tower;
        [SerializeField] private UIComboSystem _uiComboSystem;

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

        private void Start()
        {
            _comboFill.fillAmount = 0f;
            SetComboValue(0f);
        }

        public void SetComboValue(float value)
        {
            _comboValue = value;
            _comboFill.fillAmount = _comboValue;

            if (_comboValue >= 1f)
                StartCoroutine(_uiComboSystem.ComboCoroutine());
                //StartCoroutine(OnComboStart());
        }

        public float GetComboValue()
        {
            return _comboValue;
        }

        private IEnumerator OnComboStart()
        {
            //_tower.IsSlowMotion = true;

            Time.timeScale = .1f;
            yield return null;
        }
    }
}

