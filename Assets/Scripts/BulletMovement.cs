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
        //Rota al prefab hacia la dirección "newDirection".
        _myTransform.Rotate(newDirection);
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
        _speed = speedToAdd.normalized * _speedValue;
    }

    /// <summary>
    /// Method to set the initial direction of the bullet
    /// </summary>
    /// <param name="direction">Set direction</param>
    public void Setup(Vector2 direction)
    {
        //Establece la direcciñon inicial "direction".
        SetDirection(direction);
    }
    #endregion

    /// <summary>
    /// Set reference to own transform
    /// </summary>
    void Start()
    {
        _myTransform = GetComponent<Transform>();

    }

    /// <summary>
    /// Update position according to speed and time
    /// </summary>
    void Update()
    {
        //Problema _speed
        AddSpeed(new Vector3(2,0,0));
        _myTransform.position += _speed * Time.deltaTime;
        Debug.Log(_speed);
        
    }
}