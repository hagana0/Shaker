using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    public bool Enabled;//—h‚ç‚·‚©
    public AnimationCurve m_ShakeCurve = AnimationCurve.Linear(0, 1, 1, 0);//—h‚ç‚·‹­‚³‚ğŠÔ‚Å’²®‚·‚éB
    public Vector3 m_ShakeValue = new Vector3(0.1f, 0.1f, 0.1f);//—h‚ç‚·‘å‚«‚³
    Transform m_Transform;//—h‚ç‚·•¨‚Ìƒgƒ‰ƒ“ƒXƒtƒH[ƒ€
    Vector3 m_TargetPos;//‚±‚ÌˆÊ’u‚ğŠî€‚É—h‚ç‚·
    public int m_Interval = 2;//—h‚ç‚·ŠÔŠu(ƒtƒŒ[ƒ€)
    int m_IntervalCounter;
    public float m_Time = 0.5f;//—h‚ç‚·ŠÔ
    float m_CurrentTime;//0‚©‚ç1
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

    public void Shake()//—h‚ç‚·‚Í‚±‚ê‚ğŒÄ‚ñ‚Å‚­‚¾‚³‚¢B
    {
        Enabled = true;
        m_CurrentTime = 0.0f;
    }
}
