using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreakableWall : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f; // �ִ� ü��
    private float currentHealth; // ���� ü��

    private bool isBroken = false; // ���� �̹� �μ������� ����

    public Slider hpBar; // BreakableWallUI ��ũ��Ʈ���� Slider�� �Ҵ��� ����

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

                // HP UI�� ���� (Alpha�� 0���� ����)
                UpdateWallHealth(0, maxHealth);
            }
            else
            {
                // ���� ���� ��� HP UI�� ǥ�� (Alpha�� 1�� ����)
                UpdateWallHealth(currentHealth, maxHealth);
            }
        }
    }

    // ���� ü���� ������Ʈ�ϴ� �޼���  //������Ʈ�� ����� HP ui�� �ν��ϰ� �ǰ� �����ϳ�����
    public void UpdateWallHealth(float currentHealth, float maxHealth)
    {
        if (hpBar != null)
        {
            // ���� ü���� �ִ� ü�¿� ���� ������ �����Ͽ� Slider�� ������Ʈ
            hpBar.value = currentHealth / maxHealth;
        }
    }
}