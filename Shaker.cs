using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    public bool Enabled;//�h�炷��
    public AnimationCurve m_ShakeCurve = AnimationCurve.Linear(0, 1, 1, 0);//�h�炷���������ԂŒ�������B
    public Vector3 m_ShakeValue = new Vector3(0.1f, 0.1f, 0.1f);//�h�炷�傫��
    Transform m_Transform;//�h�炷���̃g�����X�t�H�[��
    Vector3 m_TargetPos;//���̈ʒu����ɗh�炷
    public int m_Interval = 2;//�h�炷�Ԋu(�t���[��)
    int m_IntervalCounter;
    public float m_Time = 0.5f;//�h�炷����
    float m_CurrentTime;//0����1
    float m_AddTime;
    Vector3 m_RandomPos;

    private void Awake()
    {
        m_Transform = transform;
        m_TargetPos = m_Transform.position;
        m_AddTime = Time.fixedDeltaTime / m_Time;
    }

    void FixedUpdate()
    {
        if (!Enabled) return;

        if (m_IntervalCounter == m_Interval)
        {
            m_RandomPos.x = Random.Range(-m_ShakeValue.x, m_ShakeValue.x);
            m_RandomPos.y = Random.Range(-m_ShakeValue.y, m_ShakeValue.y);
            m_RandomPos.z = Random.Range(-m_ShakeValue.z, m_ShakeValue.z);
            m_Transform.position = m_TargetPos + m_RandomPos * m_ShakeCurve.Evaluate(m_CurrentTime);
            m_IntervalCounter = 0;
        }
        else
        {
            m_IntervalCounter++;
        }

        m_CurrentTime += m_AddTime;
        if (m_CurrentTime >= 1.0f)
        {
            Enabled = false;
            m_Transform.position = m_TargetPos;
        }
    }

    public void Shake()//�h�炷���͂�����Ă�ł��������B
    {
        Enabled = true;
        m_CurrentTime = 0.0f;
    }
}
