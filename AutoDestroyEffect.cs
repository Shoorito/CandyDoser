using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyEffect : MonoBehaviour
{
    ParticleSystem m_particle;

    // Start is called before the first frame update
    void Start()
    {
        m_particle = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_particle.isPlaying == false)
        {
            Destroy(gameObject);
        }
    }
}
