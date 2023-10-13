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
        // Si colisiona con un objeto con la tag "Bullet"...
        if (collision.CompareTag("Bullet"))
        {
            // Informa al Game Manager que el objetivo se ha alcanzado.
            _gameManager.OnTargetReached();
        }
    }
    #endregion

    /// <summary>
    /// Set reference to GameManager
    /// </summary>
    void Start()
    {
        // Referencia al Game Manager.
        _gameManager = GetComponent<GameManager>();
    }
}