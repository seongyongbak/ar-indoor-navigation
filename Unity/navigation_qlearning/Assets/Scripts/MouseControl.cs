using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{   // 유니티 내부에서 오브젝트를 마우스 클릭으로 시뮬레이션 하는 스크립트

    public float m_fSpeed = 5.0f;
    Vector3 m_vecTarget;
    void Start()
    {
        m_vecTarget = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10000f))
            {
                m_vecTarget = hit.point;
                m_vecTarget.y = transform.position.y;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, m_vecTarget, m_fSpeed * Time.deltaTime);
    }
}

