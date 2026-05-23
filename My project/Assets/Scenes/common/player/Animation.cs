using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]

// 方向キーを押したら、アニメーションを切り替える
public class Animation : MonoBehaviour
{
    //-------------------------------------
    public string upAnime = "";      //［上向きアニメ］
    public string downAnime = "";    //［下向きアニメ］
    public string rightAnime = "";   //［右向きアニメ（左右共通）］
    //-------------------------------------
    private string nowMode = "";
    private string oldMode = "";
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
        nowMode = downAnime;
    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>();

        // ▼ 向きの反転処理を追加
        if (moveInput.x < 0)
        {
            // 左向き
            transform.localScale = new Vector3((float)-0.5, (float)0.5, (float)0.5);
        }
        else if (moveInput.x > 0)
        {
            // 右向き
            transform.localScale = new Vector3((float)0.5, (float)0.5, (float)0.5);
        }

        // ▼ アニメーション切り替え
        if (moveInput.y > 0)
        {
            nowMode = upAnime;
        }
        else if (moveInput.y < 0)
        {
            nowMode = downAnime;
        }
        else if (moveInput.x != 0)
        {
            nowMode = rightAnime; // 左右共通
        }

        if (nowMode != oldMode)
        {
            oldMode = nowMode;
            animator.Play(nowMode);
        }
    }
}
