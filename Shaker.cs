using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    public bool Enabled;//揺らすか
    public AnimationCurve m_ShakeCurve = AnimationCurve.Linear(0, 1, 1, 0);//揺らす強さを時間で調整する。
    public Vector3 m_ShakeValue = new Vector3(0.1f, 0.1f, 0.1f);//揺らす大きさ
    Transform m_Transform;//揺らす物のトランスフォーム
    Vector3 m_TargetPos;//この位置を基準に揺らす
    public int m_Interval = 2;//揺らす間隔(フレーム)
    int m_IntervalCounter;
    public float m_Time = 0.5f;//揺らす時間
    float m_CurrentTime;//0から1
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

    public void Shake()//揺らす時はこれを呼んでください。
    {
        Enabled = true;
        m_CurrentTime = 0.0f;
    }
}
