using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicRotate : MonoBehaviour
{
    [SerializeField]
    bool m_Update;

    [SerializeField]
    Transform m_SourceNode;

    [SerializeField]
    Transform m_TargetNode;

    [SerializeField]
    Vector3 m_RotateEuler;

    Quaternion m_SourceRefRotation = Quaternion.identity;
    Quaternion m_SourceRefLocalRotation = Quaternion.identity;

    Quaternion m_SourceInverseCSRotation = Quaternion.identity;
    Quaternion m_SourceApplyRotation = Quaternion.identity;

    Quaternion m_TargetParentInverseCSRotation = Quaternion.identity;
    Quaternion m_TargetRefRotation = Quaternion.identity;

    void Awake()
    {
        m_SourceRefRotation = m_SourceNode.rotation;
        m_SourceRefLocalRotation = m_SourceNode.localRotation;

        m_SourceInverseCSRotation = Quaternion.Inverse(m_SourceNode.rotation);

        m_TargetParentInverseCSRotation = Quaternion.Inverse(m_TargetNode.parent.rotation);
        m_TargetRefRotation = m_TargetNode.rotation;
    }

    void Update()
    {
        if (m_Update)
        {
            RotateObject();
        }
    }

    void RotateObject()
    {
        Quaternion rotateQuat= Quaternion.Euler(m_RotateEuler);
        m_SourceApplyRotation *= rotateQuat;
        Quaternion finalSourceLocalRotation = m_SourceRefLocalRotation * m_SourceApplyRotation;

        Quaternion targetRotateQuat = m_SourceRefRotation * m_SourceApplyRotation * m_SourceInverseCSRotation;
        m_TargetNode.transform.localRotation = m_TargetParentInverseCSRotation * targetRotateQuat * m_TargetRefRotation;

        m_SourceNode.transform.localRotation = finalSourceLocalRotation;
    }
}
