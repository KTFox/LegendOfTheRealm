using UnityEngine;
using UnityEngine.EventSystems;

namespace LegendOfTheRealm.Utilities.UI
{
    public class DragItem<T> : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler where T : class
    {
        // Variables

        private IDragSource<T> source;
        private Canvas parentCanvas;
        private Vector3 startPosition;
        private Transform originalParentTransform;


        // Methods

        private void Awake()
        {
            source = GetComponentInParent<IDragSource<T>>();
            parentCanvas = GetComponentInParent<Canvas>();
        }

        #region IDragHandler implements
        public void OnBeginDrag(PointerEventData eventData)
        {
            startPosition = transform.position;
            originalParentTransform = transform.parent;

            GetComponent<CanvasGroup>().blocksRaycasts = false;

            transform.SetParent(parentCanvas.transform, true);
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            transform.position = startPosition;
            transform.SetParent(originalParentTransform, true);

            GetComponent<CanvasGroup>().blocksRaycasts = true;

            IDragDestination<T> container;

            if (!EventSystem.current.IsPointerOverGameObject())
            {
                // Drop actionItemSO into the world

                //container = parentCanvas.GetComponent<IDragDestination<T>>();
                container = null;
            }
            else
            {
                container = GetContainer(eventData);
            }

            // Drop actionItemSO into destination container
            if (container != null)
            {
                DropItemIntoContainer(container);
            }
        }
        #endregion

        private IDragDestination<T> GetContainer(PointerEventData eventData)
        {
            if (eventData.pointerEnter != null)
            {
                var container = eventData.pointerEnter.GetComponentInParent<IDragDestination<T>>();

                return container;
            }

            return null;
        }

        private void DropItemIntoContainer(IDragDestination<T> destination)
        {
            if (ReferenceEquals(destination, source)) return;

            var destinationContainer = destination as IDragContainer<T>;
            var sourceContainer = source as IDragContainer<T>;

            if (destinationContainer == null || sourceContainer == null || ReferenceEquals(destinationContainer.Item, sourceContainer.Item))
            {
                AttempSimpleTransfer(destination);

                return;
            }

            AttempSwap(destinationContainer, sourceContainer);
        }

        private void AttempSimpleTransfer(IDragDestination<T> destination)
        {
            T draggingItem = source.Item;

            int draggingQuantity = source.Quantity;
            int acceptableQuantity = destination.GetMaxAcceptable(draggingItem);
            int quantityToTransfer = Mathf.Min(draggingQuantity, acceptableQuantity);

            if (quantityToTransfer > 0)
            {
                source.RemoveItems(quantityToTransfer);
                destination.AddItems(draggingItem, quantityToTransfer);
            }
        }

        private void AttempSwap(IDragContainer<T> destination, IDragContainer<T> source)
        {
            T removedItemFromSource = source.Item;
            T removedItemFromDestination = destination.Item;
            int removedItemNumberFromSource = source.Quantity;
            int removedItemNumberFromDestination = destination.Quantity;

            // Provisionally remove items from both sides

            source.RemoveItems(removedItemNumberFromSource);
            destination.RemoveItems(removedItemNumberFromDestination);

            // Calculate take back quantity from both sides

            int sourceTakeBackNumber = CalculateTakeBackNumber(removedItemFromSource, removedItemNumberFromSource, source, destination);
            int destinationTakeBackNumber = CalculateTakeBackNumber(removedItemFromDestination, removedItemNumberFromDestination, destination, source);

            // Do take back (if needed)

            if (sourceTakeBackNumber > 0)
            {
                source.AddItems(removedItemFromSource, sourceTakeBackNumber);
                removedItemNumberFromSource -= sourceTakeBackNumber;
            }

            if (destinationTakeBackNumber > 0)
            {
                destination.AddItems(removedItemFromDestination, destinationTakeBackNumber);
                removedItemNumberFromDestination -= destinationTakeBackNumber;
            }

            // Abort if fail to swap

            if (source.GetMaxAcceptable(removedItemFromDestination) < removedItemNumberFromDestination ||
                destination.GetMaxAcceptable(removedItemFromSource) < removedItemNumberFromSource)
            {
                source.AddItems(removedItemFromSource, removedItemNumberFromSource);
                destination.AddItems(removedItemFromDestination, removedItemNumberFromDestination);

                return;
            }

            // Do swap

            if (removedItemNumberFromDestination > 0)
            {
                source.AddItems(removedItemFromDestination, removedItemNumberFromDestination);
            }

            if (removedItemNumberFromSource > 0)
            {
                destination.AddItems(removedItemFromSource, removedItemNumberFromSource);
            }
        }

        private int CalculateTakeBackNumber(T item, int removedNumber, IDragContainer<T> removeSource, IDragContainer<T> destination)
        {
            int takeBackNumber = 0;
            int destinationMaxAcceptable = destination.GetMaxAcceptable(item);

            if (destinationMaxAcceptable < removedNumber)
            {
                takeBackNumber = removedNumber - destinationMaxAcceptable;
                int sourceMaxAcceptable = removeSource.GetMaxAcceptable(item);

                if (sourceMaxAcceptable < takeBackNumber)
                {
                    return 0;
                }
            }

            return takeBackNumber;
        }
    }
}
