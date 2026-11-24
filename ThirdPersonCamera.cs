using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float distance = 5f;
    [SerializeField] private float height = 2.2f;
    [SerializeField] private float followSmoothness = 10f;
    [SerializeField] private float lookSensitivity = 120f;
    [SerializeField] private float minPitch = -15f;
    [SerializeField] private float maxPitch = 65f;

    private float yaw;
    private float pitch = 15f;

    private void Start()
    {
        if (target != null)
            yaw = target.eulerAngles.y;
    }

    private void LateUpdate()
    {
        if (target == null) return;

#if UNITY_EDITOR || UNITY_STANDALONE
        yaw += Input.GetAxis("Mouse X") * lookSensitivity * Time.deltaTime;
        pitch -= Input.GetAxis("Mouse Y") * lookSensitivity * Time.deltaTime;
#endif
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);
        Vector3 focusPoint = target.position + Vector3.up * height;
        Vector3 desiredPosition = focusPoint - rotation * Vector3.forward * distance;

        transform.position = Vector3.Lerp(
            transform.position, desiredPosition, followSmoothness * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(focusPoint - transform.position);
    }

    // Optional: connect swipe/drag UI input to this method later.
    public void AddLookInput(Vector2 delta)
    {
        yaw += delta.x * lookSensitivity * Time.deltaTime;
        pitch -= delta.y * lookSensitivity * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
    }

    public void SetTarget(Transform newTarget) => target = newTarget;
}
