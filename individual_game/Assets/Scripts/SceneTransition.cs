using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string End; // 다음으로 이동할 씬의 이름

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 플레이어가 충돌했는지 확인
        {
            SceneManager.LoadScene(End); // 다음 씬으로 이동
        }
    }
}