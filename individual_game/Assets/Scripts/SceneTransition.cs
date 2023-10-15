using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string End; // �������� �̵��� ���� �̸�

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // �÷��̾ �浹�ߴ��� Ȯ��
        {
            SceneManager.LoadScene(End); // ���� ������ �̵�
        }
    }
}