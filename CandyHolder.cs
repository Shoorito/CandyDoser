using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyHolder : MonoBehaviour
{
    private const int m_nDefaultCandyAmount = 30;
    private const int m_nRecoverySeconds    = 10;
    private int m_nCandy   = m_nDefaultCandyAmount;
    private int m_nCounter = 0;

    public void ConsumeCandy()
    {
        if(m_nCandy > 0)
        {
            m_nCandy--;
        }
    }

    public int GetCandyAmount()
    {
        return m_nCandy;
    }

    public void AddCandy(int nAmount)
    {
        m_nCandy += nAmount;
    }

    void OnGUI()
    {
        string strLabel = "\0";

        GUI.color = Color.black;

        strLabel = "Candy : " + m_nCandy;

        if(m_nCounter > 0)
        {
            strLabel += " (" + m_nCounter +" seconds) ";
        }

        GUI.Label(new Rect(0.0f, 0.0f, 200.0f, 30.0f), strLabel);
    }

    void Update()
    {
        if(m_nCandy < m_nDefaultCandyAmount && m_nCounter <= 0)
        {
            StartCoroutine(RecoverCandy());
        }
    }

    IEnumerator RecoverCandy()
    {
        m_nCounter = m_nRecoverySeconds;

        while (m_nCounter > 0)
        {
            yield return new WaitForSeconds(1.0f);

            m_nCounter--;
        }

        m_nCandy++;
    }
}
