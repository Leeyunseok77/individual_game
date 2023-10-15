using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f; // 최대 체력
    private float currentHealth; // 현재 체력

    private bool isBroken = false; // 벽이 이미 부서졌는지 여부

    private void Start()
    {
        currentHealth = maxHealth;
    }

    // 벽 부수기
    public void BreakWall(float damage)
    {
        if (!isBroken)
        {
            // 데미지를 현재 체력에서 빼기
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                // 벽 부수기
                isBroken = true;

                // 벽 제거
                Destroy(gameObject);
            }
        }
    }
}