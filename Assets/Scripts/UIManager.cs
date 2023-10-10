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
    #endregion

    #region methods
    /// <summary>
    /// Called when the player presses start button.
    /// Needs to inform GameManager that the button has been pressed.
    /// </summary>
    public void OnPressStart()
    {
        _gameManager.OnPressedStart();
        _mainMenu.SetActive(false);
    }

    /// <summary>
    /// UI Manager provides this method to allow managament of Main Menu
    /// </summary>
    /// <param name="newState"></param>
    public void SetMainMenu(bool newState)
    {
        //_mainMenu.SetActive(!newState);
    }

    /// <summary>
    /// UI Manager provides this methif to allow managament of Victory Screen
    /// </summary>
    /// <param name="newState"></param>
    public void SetVictoryScreen(bool newState)
    {
        _victoryScreen.SetActive(true);
    }
    #endregion

    /// <summary>
    /// Set reference to Game Manager
    /// </summary>
    void Start()
    {
        //Se queda por defecto lo que esté en el editor por lo que en un principio esto no haría falta
        _mainMenu.SetActive(true);
        _victoryScreen.SetActive(false);
        _gameManager = GetComponent<GameManager>();

    }
}

