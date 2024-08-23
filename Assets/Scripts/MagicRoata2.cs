using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicRoata2 : MonoBehaviour
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
    Quaternion m_TargetRefRotation = Quaternion.identity;
    
    Quaternion m_SourceRefLocalRotation = Quaternion.identity;
    
    Quaternion m_SourceApplyRotation = Quaternion.identity;

    void Awake()
    {
        m_SourceRefRotation = m_SourceNode.rotation;
        m_TargetRefRotation = m_TargetNode.rotation;
        
        m_SourceRefLocalRotation = m_SourceNode.localRotation;
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
        m_SourceNode.transform.localRotation = finalSourceLocalRotation;
        Quaternion sourceRotationAnimated = m_SourceNode.transform.rotation;

        m_TargetNode.rotation = m_TargetRefRotation * Quaternion.Inverse(m_SourceRefRotation) * sourceRotationAnimated;
    }
}
