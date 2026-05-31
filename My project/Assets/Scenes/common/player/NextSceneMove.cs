using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // 次に読み込むシーン名
    public string nextSceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // プレイヤーに触れたら
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}