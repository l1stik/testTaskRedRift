using _Project.Scripts.Model;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.View
{
    public class CardEntityView
        : MonoBehaviour 
    {
        #region VARIABLES

        [SerializeField]
        private Image _overlayImage;
        
        [SerializeField]
        private TMP_Text _tmp_TextHP;
        
        [SerializeField]
        private TMP_Text _tmp_TextAttack;
        
        [SerializeField]
        private TMP_Text _tmp_TextMana;
        
        private const string URL = "https://picsum.photos/200";
        #endregion
        
        private void Start()
        {
            if (_overlayImage != null) 
                StartCoroutine(ImageHandler.SetupImageFromURL(_overlayImage, URL));
        }

        public void SetValueHp(int value)
        {
            StartCoroutine(AnimationCounter.CountTo(_tmp_TextHP, value));
        }
        
        public void SetValueAttack(int value)
        {
            StartCoroutine(AnimationCounter.CountTo(_tmp_TextAttack, value));
        }
        
        public void SetValueMana(int value)
        {
            StartCoroutine(AnimationCounter.CountTo(_tmp_TextMana, value));
        }
    }
}