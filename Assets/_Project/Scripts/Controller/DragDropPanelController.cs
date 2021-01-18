using _Project.Scripts.Model;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Project.Scripts.Controller
{
    public class DragDropPanelController 
        : MonoBehaviour, IDropHandler
    {
        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag != null)
            {
                eventData.pointerDrag.GetComponent<DragDropEntityModel>().IsOtherSpace = true;

                eventData.pointerDrag.GetComponent<RectTransform>().position =
                    GetComponent<RectTransform>().position;
            }
        }
    }
}