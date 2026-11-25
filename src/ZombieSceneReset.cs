using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombieKillPlayerTrigger : MonoBehaviour
{
    public string playerTag = "Player";  // XR Origin에 설정한 태그

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            Debug.Log("트리거로 플레이어 충돌 감지됨 → 씬 리셋!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
