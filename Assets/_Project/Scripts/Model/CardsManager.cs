using System;
using _Project.Scripts.View;
using UnityEngine;
using Random = System.Random;

namespace _Project.Scripts.Model
{
    public class CardsManager 
        : MonoBehaviour
    {
        #region VARIABLES

        [SerializeField] 
        private RectTransform _rootPanel;
        
        [SerializeField] 
        private RectTransform _card;

        [SerializeField] 
        private int _countCard;
        
        [SerializeField] 
        private int _startAngle = 10;

        private int cardNum = 0;  
        
        #endregion
        private void Awake()
        {
            for (var i = 0; i < _countCard; i++)
            { 
                CreateInstanceCard(i);
            }
        }

        private void CreateInstanceCard(int indexCard)
        {
            var panelSpaceRect = _rootPanel.rect;
            var stepRotation = (float)Math.Abs(_startAngle - _startAngle * -1) / _countCard;
         
            var newCard = Instantiate(_card, _rootPanel, true);
            newCard.transform.gameObject.AddComponent<CanvasGroup>();
            newCard.transform.gameObject.AddComponent<DragDropEntityModel>();

            var sizeCard = new Vector2((panelSpaceRect.size.x / _countCard), panelSpaceRect.size.y);
            var pointFirstCard = panelSpaceRect.xMin + sizeCard.x / 2;
            
            newCard.localPosition = new Vector2(pointFirstCard + (sizeCard.x * indexCard), (_rootPanel.rect.center.y));
            newCard.Rotate( new Vector3( 0, 0, _startAngle - stepRotation * indexCard));
            newCard.sizeDelta = sizeCard;
        }
        
        public void SetValueCardForTest()
        {
            if (cardNum >= _countCard) cardNum = 0;
            
            var rnd = new Random();
            var val = rnd.Next(-2, 9);

            var method = rnd.Next(0, 3);

            switch (method)
            {
                case 0:
                    _rootPanel.GetChild(cardNum).gameObject.GetComponent<CardEntityView>().SetValueAttack(val);
                    break;
                case 1:
                    _rootPanel.GetChild(cardNum).gameObject.GetComponent<CardEntityView>().SetValueHp(val);
                    break;
                case 2:
                    _rootPanel.GetChild(cardNum).gameObject.GetComponent<CardEntityView>().SetValueMana(val);
                    break;
            }
            cardNum++;
        }
    }
}