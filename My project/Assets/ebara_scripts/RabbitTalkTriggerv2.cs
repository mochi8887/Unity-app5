using UnityEngine;
using UnityEngine.InputSystem;

public class RabbitTalkTriggerv2 : MonoBehaviour
{
    [SerializeField] private GameObject heartRoot;    // ハート
    [SerializeField] private GameObject bubbleRoot;   // コメント吹き出し
    [SerializeField] private GameObject messageRoot;  // コメントメッセージ

    private bool playerInRange;
    private int talkStep = 0;

    void Start()
    {
        if (heartRoot != null)
            heartRoot.SetActive(false);

        if (bubbleRoot != null)
            bubbleRoot.SetActive(false);

        if (messageRoot != null)
            messageRoot.SetActive(false);
    }

    void Update()
    {
        if (!playerInRange) return;

        if (Keyboard.current != null && Keyboard.current.enterKey.wasPressedThisFrame)
        {
            talkStep++;

            if (talkStep == 1)
            {
                // Enter 1回目：ハート + コメント吹き出し
                if (heartRoot != null)
                    heartRoot.SetActive(true);

                if (bubbleRoot != null)
                    bubbleRoot.SetActive(true);

                if (messageRoot != null)
                    messageRoot.SetActive(false);
            }
            else if (talkStep == 2)
            {
                // Enter 2回目：コメントメッセージを表示
                if (heartRoot != null)
                    heartRoot.SetActive(false);

                if (bubbleRoot != null)
                    bubbleRoot.SetActive(true);

                if (messageRoot != null)
                    messageRoot.SetActive(true);
            }
            else
            {
                // Enter 3回目：全部消してリセット
                if (heartRoot != null)
                    heartRoot.SetActive(false);

                if (bubbleRoot != null)
                    bubbleRoot.SetActive(false);

                if (messageRoot != null)
                    messageRoot.SetActive(false);

                talkStep = 0;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("MainCharacter"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("MainCharacter"))
        {
            playerInRange = false;
            talkStep = 0;

            if (heartRoot != null)
                heartRoot.SetActive(false);

            if (bubbleRoot != null)
                bubbleRoot.SetActive(false);

            if (messageRoot != null)
                messageRoot.SetActive(false);
        }
    }
}