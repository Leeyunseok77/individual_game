using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f; // �ִ� ü��
    private float currentHealth; // ���� ü��

    private bool isBroken = false; // ���� �̹� �μ������� ����

    private void Start()
    {
        currentHealth = maxHealth;
    }

    // �� �μ���
    public void BreakWall(float damage)
    {
        if (!isBroken)
        {
            // �������� ���� ü�¿��� ����
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                // �� �μ���
                isBroken = true;

                // �� ����
                Destroy(gameObject);
            }
        }
    }
}