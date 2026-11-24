using UnityEngine;

public class MissionTrigger : MonoBehaviour
{
    [SerializeField] private string missionTitle = "Welcome to Vice Coast";
    [TextArea]
    [SerializeField] private string missionDescription =
        "Explore the city and find the next marker.";

    private bool activated;

    private void OnTriggerEnter(Collider other)
    {
        if (activated || !other.CompareTag("Player")) return;

        activated = true;
        Debug.Log("MISSION: " + missionTitle + " — " + missionDescription);
    }

    public void ResetMissionMarker() => activated = false;
}
