using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TargetComponent : MonoBehaviour
{
    #region references
    /// <summary>
    /// Reference to Game Manager
    /// </summary>
    private GameManager _gameManager;
    #endregion

    #region methods
    /// <summary>
    /// Method to detect if a bullet reaches the target and inform the GameManager
    /// </summary>
    /// <param name="collision">Colliding object</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
       BulletMovement _bullet = collision.GetComponent<BulletMovement>();
        
        if(_bullet != null) { _gameManager.OnTargetReached(); }
    }
    #endregion

    /// <summary>
    /// Set reference to GameManager
    /// </summary>
    void Start()
    {
        // Referencia al Game Manager.
        _gameManager = FindObjectOfType<GameManager>();
    }
}