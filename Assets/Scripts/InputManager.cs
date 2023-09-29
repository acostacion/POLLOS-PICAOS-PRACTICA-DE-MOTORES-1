using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
public class InputManager : MonoBehaviour
{
    #region references
    /// <summary>
    /// Reference to player's LookAtPositionComponent
    /// </summary>
    [SerializeField]
    private LookAtPositionComponent _playerLookAt;

    /// <summary>
    /// Reference to player's ShootingComponent
    /// </summary>
    [SerializeField]
    private ShootingComponent _playerShooting;
    #endregion

    /// <summary>
    /// 1. Update look at position
    /// 2. Receive button input and shoot bullet when it occurs
    /// </summary>
    void Update()
    {
        //_playerLookAt.SetLookAtPosition();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _playerShooting.Shoot();
        }


    }
}