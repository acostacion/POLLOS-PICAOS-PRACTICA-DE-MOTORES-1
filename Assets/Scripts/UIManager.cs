using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UIManager : MonoBehaviour
{
    #region references
    /// <summary>
    /// Reference to Main Menu
    /// (Established in editor)
    /// </summary>
    [SerializeField]
    private GameObject _mainMenu;

    /// <summary>
    /// Reference to Victory Screen
    /// (Established in editor)
    /// </summary>
    [SerializeField]
    private GameObject _victoryScreen;

    /// <summary>
    /// Reference to GameManager
    /// </summary>
    private GameManager _gameManager;

    //Para poder activar y desactivar el input
    private InputManager _inputManager;
    #endregion

    #region methods
    /// <summary>
    /// Called when the player presses start button.
    /// Needs to inform GameManager that the button has been pressed.
    /// </summary>
    public void OnPressStart()
    {
        // Informa al GameManager que se ha presionado el botón start.
        _gameManager.OnPressedStart();

        // Desactiva el menú principal.
        _mainMenu.SetActive(false);

        //Activamos que el jugador pueda disparar
        _inputManager.enabled = true;

    }

    /// <summary>
    /// UI Manager provides this method to allow managament of Main Menu
    /// </summary>
    /// <param name="newState"></param>
    public void SetMainMenu(bool newState)
    {
        // Por medio de "newState" activa o desactiva el menú principal.
        _mainMenu.SetActive(newState);
    }

    /// <summary>
    /// UI Manager provides this methif to allow managament of Victory Screen
    /// </summary>
    /// <param name="newState"></param>
    public void SetVictoryScreen(bool newState)
    {
        // Por medio de "newState" activa o desactiva el menú de victoria.
        _victoryScreen.SetActive(newState);
    }
    #endregion

    /// <summary>
    /// Set reference to Game Manager
    /// </summary>
    void Start()
    {
        _gameManager = GetComponent<GameManager>();

        _inputManager = GetComponent<InputManager>();
    }
}

