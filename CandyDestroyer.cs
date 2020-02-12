using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyDestroyer : MonoBehaviour
{
    public int         m_nReward           = 0;
    public CandyHolder m_chHolder          = null;
    public GameObject  m_objEffectPrefab   = null;
    public Vector3     m_vecEffectRotation = new Vector3(0.0f, 0.0f, 0.0f);

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Candy")
        {
            m_chHolder.AddCandy(m_nReward);

            Destroy(collider.gameObject);

            if(m_objEffectPrefab != null)
            {
                Instantiate
                (
                    m_objEffectPrefab,
                    collider.transform.position,
                    Quaternion.Euler(m_vecEffectRotation)
                );
            }
        }
    }
}
