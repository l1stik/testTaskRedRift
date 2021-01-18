using UnityEngine;
using UnityEngine.EventSystems;

namespace _Project.Scripts.Model
{
    public class DragDropEntityModel 
        : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        #region VARIABLES
        
        private CanvasGroup _canvasGroup;
        private RectTransform _rectTransform;
        private Vector3 _defaultPositionCard;
        public bool IsOtherSpace { private get; set; }
        
        #endregion
        
        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            IsOtherSpace = false;
            _defaultPositionCard = transform.position;
            _canvasGroup.blocksRaycasts = false;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (!IsOtherSpace) 
                transform.position = _defaultPositionCard;
            
            _canvasGroup.blocksRaycasts = true;
        }

        public void OnDrag(PointerEventData eventData)
        {
            _rectTransform.anchoredPosition += eventData.delta;
        }
        
        public void OnPointerDown(PointerEventData eventData)
        {
        }
    }
}