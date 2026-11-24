using UnityEngine;

public class WorldGridGizmo : MonoBehaviour
{
    [SerializeField] private float worldSize = 800f;
    [SerializeField] private int cellsPerSide = 10;

    private void OnDrawGizmos()
    {
        if (cellsPerSide < 1) return;

        float cell = worldSize / cellsPerSide;
        Vector3 origin = transform.position - Vector3.right * (worldSize * 0.5f)
                                           - Vector3.forward * (worldSize * 0.5f);

        Gizmos.color = new Color(0.2f, 0.8f, 1f, 0.55f);
        for (int i = 0; i <= cellsPerSide; i++)
        {
            float offset = i * cell;
            Gizmos.DrawLine(origin + Vector3.right * offset,
                            origin + Vector3.right * offset + Vector3.forward * worldSize);
            Gizmos.DrawLine(origin + Vector3.forward * offset,
                            origin + Vector3.forward * offset + Vector3.right * worldSize);
        }
    }
}
