using _Project.Scripts.Model;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Controller
{
    public class ButtonsEntity 
        : MonoBehaviour
    {
        #region VARIABLES
        
        [SerializeField]
        private Button _button;
        
        [SerializeField]
        private CardsManager _cardsManager;
        
        #endregion
        
        public void Start()
        {
            _button.onClick.AddListener(_cardsManager.SetValueCardForTest);
        }
    }
}