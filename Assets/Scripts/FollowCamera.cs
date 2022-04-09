using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    private Vector3 offset;
    [SerializeField, Range(0.0f, 1.0f)]
    private float degree = 0.095f;
    private void Start()
    {
        offset = transform.position - playerTransform.position;
    }
    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, playerTransform.position + offset, degree);
    }

#if UNITY_EDITOR
    [Header("For Settings (Set Start Position)")]
    [SerializeField] private Vector3 positionRelativePlayer = new Vector3(0.0f, 1.429999f, -3.380001f);
    [SerializeField] private Vector3 rotationRelativePlayer = new Vector3(21.16f, 0.0f, 0.0f);
    [ContextMenu("Set Start Position")]
    public void SetStartPosition()
    {
        if(playerTransform == null)
        {
            Debug.Log("First, add a player to the \"Player Transform\" field");
        }
        else
        {
            transform.SetParent(playerTransform);
            transform.localPosition = positionRelativePlayer;
            transform.localRotation = Quaternion.Euler(rotationRelativePlayer);
            transform.SetParent(null);
        }
    }
#endif
}
