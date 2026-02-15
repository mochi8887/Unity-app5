using UnityEngine;
using UnityEngine.InputSystem;

public class RabbitTalkTrigger : MonoBehaviour
{
    [SerializeField] private GameObject bubbleRoot;

    private bool playerInRange;

    void Start()
    {
        if (bubbleRoot != null) bubbleRoot.SetActive(false);
    }

    void Update()
    {
        if (!playerInRange) return;

        // Enter
        if (Keyboard.current != null && Keyboard.current.enterKey.wasPressedThisFrame)
        {
            if (bubbleRoot != null)
                bubbleRoot.SetActive(!bubbleRoot.activeSelf);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("MainCharacter")) playerInRange = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("MainCharacter"))
        {
            playerInRange = false;
            if (bubbleRoot != null) bubbleRoot.SetActive(false);
        }
    }
}
