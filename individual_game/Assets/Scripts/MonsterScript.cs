using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // ���Ͱ� �׾��� �� ������ ������ �̰��� �����մϴ�.
        // ��: ���� ���, �ִϸ��̼� ���, ������ ��� ��
        // ���⿡ �ʿ��� �߰� ������ �����ϼ���.

        // ���͸� �����մϴ�.
        Destroy(gameObject);
    }
}
