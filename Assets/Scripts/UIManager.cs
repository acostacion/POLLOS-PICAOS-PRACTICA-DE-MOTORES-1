using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UIManager : MonoBehaviour
{
    // �C�MO MODIFICAMOS NEWSTATE?

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
    #endregion

    #region methods
    /// <summary>
    /// Called when the player presses start button.
    /// Needs to inform GameManager that the button has been pressed.
    /// </summary>
    public void OnPressStart()
    {
        // Informa al GameManager que se ha presionado el bot�n start.
        _gameManager.OnPressedStart();

        // Desactiva el men� principal.
        _mainMenu.SetActive(false);
    }

    /// <summary>
    /// UI Manager provides this method to allow managament of Main Menu
    /// </summary>
    /// <param name="newState"></param>
    public void SetMainMenu(bool newState)
    {
        // Por medio de "newState" activa o desactiva el men� principal.
        _mainMenu.SetActive(newState);
    }

    /// <summary>
    /// UI Manager provides this methif to allow managament of Victory Screen
    /// </summary>
    /// <param name="newState"></param>
    public void SetVictoryScreen(bool newState)
    {
        // Por medio de "newState" activa o desactiva el men� de victoria.
        _victoryScreen.SetActive(newState);
    }
    #endregion

    /// <summary>
    /// Set reference to Game Manager
    /// </summary>
    void Start()
    {
        //Creo que deber�an quitarse tanto _mainMenu.SetActive(true) y _victoryScreen.SetActive(false) porque es redundante.

        // Muestra el men� principal al inicio.
        _mainMenu.SetActive(true);

        // Oculta el men� de victoria al inicio.
        _victoryScreen.SetActive(false);

        _gameManager = GetComponent<GameManager>();

    }
}

