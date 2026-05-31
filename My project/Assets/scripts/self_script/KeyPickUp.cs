using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    [SerializeField] private string playerTag = "Player";

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"[Key Trigger] {gameObject.name} hit by {other.gameObject.name} tag={other.tag}");

        if (!other.CompareTag(playerTag)) return;

        Debug.Log($"[Key Collected] {gameObject.name}");

        if (KeyGameManager_1.Instance != null)
        {
            KeyGameManager_1.Instance.NotifyKeyCollected();
        }

        // 鍵を消す
        Destroy(gameObject);
    }
}
