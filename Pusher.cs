using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour
{
    public float m_fSpeed = 0.0f;
    public float m_fAmplitude = 0.0f;

    private Vector3 m_vecStartPosition = new Vector3(0.0f, 0.0f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
        m_vecStartPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        float fZMover = 0.0f;

        fZMover = m_fAmplitude * Mathf.Sin(Time.time * m_fSpeed);

        transform.localPosition = m_vecStartPosition + new Vector3(0.0f, 0.0f, fZMover);
    }
}
