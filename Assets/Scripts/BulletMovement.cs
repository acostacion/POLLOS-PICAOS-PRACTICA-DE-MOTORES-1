using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletMovement : MonoBehaviour
{
    #region parameters
    /// <summary>
    /// Translation speed of the bullet
    /// </summary>
    [SerializeField]
    private float _speedValue = 1.0f;
    #endregion

    #region references
    private Transform _myTransform;
    #endregion

    #region properties
    private Vector3 _speed;

    public Vector3 Speed { get { return _speed; } }
    #endregion

    #region methods
    /// <summary>
    /// Method to set the direction for the translation of the bullet.
    /// </summary>
    /// <param name="newDirection">Set direction</param>
    public void SetDirection(Vector3 newDirection)
    {
        ////Lo que hacemos para cambiar de dirección es modificar la velocidad
        //AddSpeed(newDirection);
        ////Rota al prefab hacia la dirección "newDirection".
        //_myTransform.Rotate(_speed);

        _speed = newDirection.normalized;
        _speed *= _speedValue;
    }

    /// <summary>
    /// Method to add speed to the bullet while keeping it module is kept constant
    /// 1. Add the desired extra speed.
    /// 2. Normalize speed
    /// 3. Multiplay per _speed value
    /// </summary>
    /// <param name="speedToAdd">Speed to be added (vector)</param>
    public void AddSpeed(Vector3 speedToAdd)
    {
        // CREO QUE HAY QUE MODIFICAR ESTO PARA EL ATTRACTCOMPONENT.
        _speed = speedToAdd.normalized * _speedValue;
    }

    /// <summary>
    /// Method to set the initial direction of the bullet
    /// </summary>
    /// <param name="direction">Set direction</param>
    public void Setup(Vector2 direction)
    {
        //Establece la dirección inicial de la bala "direction".
        //SetDirection(direction);
        _myTransform.Rotate(direction);
    }
    #endregion

    /// <summary>
    /// Set reference to own transform
    /// </summary>
    void Start()
    {
        //Esto habría que cambiarlo creo
        AddSpeed(new Vector3(1, 0, 0));
        _myTransform = GetComponent<Transform>();

    }

    /// <summary>
    /// Update position according to speed and time
    /// </summary>
    void Update()
    {
        _myTransform.Translate(_speed * Time.deltaTime);
    }
}