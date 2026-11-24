using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] private RectTransform background;
    [SerializeField] private RectTransform handle;
    [SerializeField, Range(0.1f, 1f)] private float handleRange = 0.65f;

    public Vector2 Value { get; private set; }

    private void Awake()
    {
        if (background == null) background = transform as RectTransform;
        if (background == null || handle == null)
            Debug.LogWarning("VirtualJoystick: assign Background and Handle in the Inspector.", this);
    }

    public void OnPointerDown(PointerEventData eventData) => UpdateValue(eventData);
    public void OnDrag(PointerEventData eventData) => UpdateValue(eventData);

    public void OnPointerUp(PointerEventData eventData)
    {
        Value = Vector2.zero;
        if (handle != null) handle.anchoredPosition = Vector2.zero;
    }

    private void UpdateValue(PointerEventData eventData)
    {
        if (background == null || handle == null) return;

        if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(
            background, eventData.position, eventData.pressEventCamera, out Vector2 localPoint))
            return;

        Vector2 halfSize = background.rect.size * 0.5f;
        Vector2 normalized = new Vector2(
            halfSize.x > 0 ? localPoint.x / halfSize.x : 0,
            halfSize.y > 0 ? localPoint.y / halfSize.y : 0);

        Value = Vector2.ClampMagnitude(normalized, 1f);
        handle.anchoredPosition = Value * (Mathf.Min(halfSize.x, halfSize.y) * handleRange);
    }
}
