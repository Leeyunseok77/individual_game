using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // �÷��̾� ������Ʈ�� Transform ������Ʈ�� ���⿡ �����ϼ���.
    public Vector3 offset;   // ī�޶�� �÷��̾� ���� �������� �����ϼ���.

    void LateUpdate()
    {
        if (target != null)
        {
            // �÷��̾��� ��ġ�� �������� ���� ��ġ�� ī�޶� �̵���ŵ�ϴ�.
            transform.position = target.position + offset;
        }
    }
}
