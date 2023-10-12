using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    #region references
    private InputManager _inputManager;
    private GameManager _gameManager;
    private UIManager _UIManager;
    #endregion

    #region methods
    /// <summary>
    /// Public method used to inform GameManager that the target has been reached
    /// </summary>
    public void OnTargetReached() // Cuando se alcanza el objetivo...
    {
        // ... el juego finaliza.
        GameFinishes();
    }

    /// <summary>
    /// Public method used to inform GameManager that the player has clicked Start button
    /// </summary>
    public void OnPressedStart() // Al presionar el start...
    {
        // ... el juego comienza.
        GameStarts();
    }

    /// <summary>
    /// GameManager executes this method to set required elements for Start Menu
    /// </summary>
    private void StartMenu()
    {
        // Llama al UIManager y activa el menú principal cuando se llama a este método.
        _UIManager.SetMainMenu(true);
    }

    /// <summary>
    /// GameManager exectes this method to set required elements to start the Game
    /// </summary>
    private void GameStarts()
    {
        // Llama al UIManager para que al presionar start se cierre el menú.
        _UIManager.SetMainMenu(false);
    }

    /// <summary>
    /// GameManager executes this method to set the required elements to finish the Game
    /// </summary>
    private void GameFinishes()
    {
        // Llama al UIManager para que cuando el juego termine salga la pantalla de victoria.
        _UIManager.SetVictoryScreen(true);
    }
    #endregion

    /// <summary>
    /// Initial setup of references and call to StartMenu
    /// </summary>
    void Start()
    {
        _inputManager = GetComponent<InputManager>();
        _gameManager = this; // _gameManager = GetComponent<GameManager>();
        _UIManager = GetComponent<UIManager>();
        StartMenu(); // Inicializa el menú al comienzo del todo.
    }
}

