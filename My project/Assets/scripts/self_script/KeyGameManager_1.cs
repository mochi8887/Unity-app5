using UnityEngine;

public class KeyGameManager_1 : MonoBehaviour
{
    public static KeyGameManager_1 Instance { get; private set; }

    [Header("Door to remove when all keys collected")]
    [SerializeField] private GameObject door;

    private int totalKeys;
    private int collectedKeys;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

    }

    private void Start()
    {
        // シーン内にある Key を全部数える
        totalKeys = FindObjectsOfType<KeyPickup>().Length;
        collectedKeys = 0;

        Debug.Log($"[GM] totalKeys={totalKeys} / door={(door ? door.name : "NULL")} / this={gameObject.name}");

        // 鍵が0個なら最初からドア消す
        TryOpenDoor();
    }

    public void NotifyKeyCollected()
    {
        collectedKeys++;
        Debug.Log($"[GM] collectedKeys={collectedKeys}/{totalKeys} / door={(door ? door.name : "NULL")}");
        TryOpenDoor();
    }

    private void TryOpenDoor()
    {
        if (door == null) return;

        if (collectedKeys >= totalKeys)
        {
            // 消したいだけなら SetActive(false) が安全
            door.SetActive(false);

        }
    }
}
