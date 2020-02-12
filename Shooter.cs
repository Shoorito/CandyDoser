using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    private const int   m_nSphereCandyFrequency = 3;
    private const int   m_nMaxShotPower         = 5;
    private const int   m_nRecoverySeconds      = 3;
    private int         m_nSampleCandyCount     = 0;
    private int         m_nShotPower            = m_nMaxShotPower;
    private AudioSource m_audioShot             = null;

    public GameObject[] m_arCandyPrefabs        = { };
    public GameObject[] m_arCandySquarePrefabs  = { };
    public GameObject   m_objCandyHolder        = null;
    public CandyHolder  m_chHolder              = null;
    public float        m_fShotSpeed            = 0.0f;
    public float        m_fShotTorque           = 0.0f;
    public float        m_fBaseWidth            = 0.0f;

    void Start()
    {
        m_audioShot = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) Shot();
    }

    GameObject SampleCandy()
    {
        int nIndex           = 0;
        GameObject objPrefab = null;

       if(m_nSampleCandyCount % m_nSphereCandyFrequency == 0)
       {
            nIndex    = Random.Range(0, m_arCandyPrefabs.Length);
            objPrefab = m_arCandyPrefabs[nIndex];
       }
       else
       {
            nIndex    = Random.Range(0, m_arCandySquarePrefabs.Length);
            objPrefab = m_arCandySquarePrefabs[nIndex];
       }

        m_nSampleCandyCount++;

        return objPrefab;
    }

    Vector3 GetInstantiatePosition()
    {
        float   fXpos = 0.0f;
        Vector3 vecResult;

        fXpos     = m_fBaseWidth * (Input.mousePosition.x / Screen.width) - (m_fBaseWidth / 2.0f);
        vecResult = transform.position + new Vector3(fXpos, 0.0f, 0.0f);

        return vecResult;
    }

    void Shot()
    {
        if(m_chHolder.GetCandyAmount() <= 0)
        {
            return;
        }

        if(m_nShotPower <= 0)
        {
            return;
        }

        Rigidbody  rbCandy;
        GameObject objCandy;

        objCandy  = (GameObject)Instantiate(SampleCandy(), GetInstantiatePosition(), Quaternion.identity);
        objCandy.transform.parent = m_objCandyHolder.transform;

        rbCandy   = objCandy.GetComponent<Rigidbody>();

        rbCandy.AddForce(transform.forward * m_fShotSpeed);
        rbCandy.AddTorque(new Vector3(0.0f, m_fShotTorque, 0.0f));

        m_chHolder.ConsumeCandy();

        ConsumePower();

        m_audioShot.Play();
    }

    void OnGUI()
    {
        string strLabel = "";
        GUI.color       = Color.black;

        for (int nRepeat = 0; nRepeat < m_nShotPower; nRepeat++)
        {
            strLabel += '+';
        }

        GUI.Label(new Rect(0.0f, 15.0f, 150.0f, 30.0f), strLabel);
    }

    void ConsumePower()
    {
        m_nShotPower--;

        StartCoroutine(RecoverPower());
    }

    IEnumerator RecoverPower()
    {
        yield return new WaitForSeconds(m_nRecoverySeconds);

        m_nShotPower++;
    }
}
