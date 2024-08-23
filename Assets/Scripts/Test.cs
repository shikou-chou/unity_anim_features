using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    private Vector3 m_FirstEuler;

    [SerializeField]
    private Vector3 m_SecondEuler;

    [SerializeField]
    private Vector3 m_MutiplyResult;

    [SerializeField]
    private Transform m_Child;

    [SerializeField]
    private Vector3 m_InverseChainResult;

    void OnValidate()
    {
        Quaternion quat1 = Quaternion.Euler(m_FirstEuler);
        Quaternion quat2 = Quaternion.Euler(m_SecondEuler);
        Quaternion quat3 = quat1 * quat2;
        m_MutiplyResult = quat3.eulerAngles;

        Quaternion t = Quaternion.identity;
        for (Transform it = m_Child; it != null; it = it.parent)
        {
            t = t * Quaternion.Inverse(it.localRotation);
        }
        m_InverseChainResult = t.eulerAngles;
    }
}
