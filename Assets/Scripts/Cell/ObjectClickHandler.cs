using Interfaces;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Cell
{
    [RequireComponent(typeof(Cell))]
    public class ObjectClickHandler : MonoBehaviour, IPointerClickHandler, ISubscription<UnityAction<CellObject>>
    {
        private UnityEvent<CellObject> _clickedEvent;

        private void Awake()
        {
            _clickedEvent = new UnityEvent<CellObject>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("Clicked");
            global::Cell.Cell cell = GetComponent<global::Cell.Cell>();
            _clickedEvent?.Invoke(cell.CellObject);
        }

        public void Subscribe(UnityAction<CellObject> listenerMethod)
        {
            Debug.Log("Subscribe to clicked");
            _clickedEvent.AddListener(listenerMethod);
        }

        public void Unsubscribe(UnityAction<CellObject> listenerMethod)
        {
            _clickedEvent.RemoveListener(listenerMethod);
        }

        public void UnsubscribeAll()
        {
            _clickedEvent.RemoveAllListeners();
        }
    }
}
