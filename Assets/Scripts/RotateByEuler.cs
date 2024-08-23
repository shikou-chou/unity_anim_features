using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateByEuler : MonoBehaviour
{
    [SerializeField]
    private Vector3 m_Euler;

    [SerializeField]
    private bool m_StartRotate;

    [SerializeField]
    GameObject m_RotateNode;

    [SerializeField]
    private bool m_Update;

    void Update()
    {
        if (m_Update)
            RotateObject();
    }

    void RotateObject()
    {
        Quaternion rotationQuaternion = Quaternion.Euler(m_Euler);
        m_RotateNode.transform.localRotation *= rotationQuaternion;
    }

    private void OnValidate()
    {
        if (m_StartRotate)
        {
            RotateObject();
            m_StartRotate = false;
        }
    }
}
