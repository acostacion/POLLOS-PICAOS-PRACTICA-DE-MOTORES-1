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
        // Hace que el objeto jugador mire a la posición del ratón.
        _playerLookAt.SetLookAtPosition(Input.mousePosition);

        // Si se presiona clic izquierdo
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // El jugador dispara
            _playerShooting.Shoot();
        }

    }
}