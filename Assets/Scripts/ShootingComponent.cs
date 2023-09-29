using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ShootingComponent : MonoBehaviour
{
    #region references
    /// <summary>
    /// Prefab object to be cloned in run time
    /// </summary>
    [SerializeField]
    private GameObject _bulletPrefab;
    /// <summary>
    /// Reference to own transform
    /// </summary>
    private Transform _myTransform;
    #endregion

    #region methods
    /// <summary>
    /// Method to shoot a bullet:
    /// 1. Instantiate clone of bullet prefab
    /// Set proper direction according to player's rotation
    /// </summary>
    public void Shoot()
    {
        Instantiate(_bulletPrefab);
    }
    #endregion

    /// <summary>
    /// Set refrence to own transform
    /// </summary>
    void Start()
    {
        _myTransform = transform;

    }
}