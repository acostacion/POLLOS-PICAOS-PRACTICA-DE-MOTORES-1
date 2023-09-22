using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LookAtPositionComponent : MonoBehaviour
{
    #region references
    /// <summary>
    /// Referene to own transform
    /// </summary>
    private Transform _myTransform;
    #endregion

    /// <summary>
    /// Point to look at
    /// </summary>
    #region properties
    private Vector3 _lookAtPosition;
    #endregion

    #region methods
    public void SetLookAtPosition(Vector3 mousePosition)
    {
        //El transform mira a la posici�n "mousePosition".
        _myTransform.LookAt(mousePosition);
    }
    #endregion

    /// <summary>
    /// Set reference to own transform
    /// </summary>
    void Start()
    {
        _myTransform = transform;
    }

    /// <summary>
    /// Set rotation to make the player look at the lookAtPosition
    /// This is difficult to understand, so the code has been kept for students to use it
    /// </summary>
    void Update()
    {
        SetLookAtPosition(_lookAtPosition);
        Quaternion rotation = Quaternion.LookRotation
        (_lookAtPosition - transform.position, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
    }
}