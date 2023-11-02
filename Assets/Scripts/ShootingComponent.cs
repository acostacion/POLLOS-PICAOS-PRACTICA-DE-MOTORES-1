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
        // Instanciamos un nuevo objeto de bala en la posici�n y rotaci�n del objeto actual (ca��n).
        Instantiate(_bulletPrefab, _myTransform.position, _myTransform.rotation)

            // Obtenemos el BulletMovement.
            .GetComponent<BulletMovement>()

            // Con el BulletMovement configuramos la bala para que se mueva hacia la posici�n del cursor del rat�n (vector = posici�n rat�n - posici�n actual).
            .Setup(Camera.main.ScreenToWorldPoint(Input.mousePosition) - _myTransform.position);
    }
    #endregion

    /// <summary>
    /// Set refrence to own transform
    /// </summary>
    void Start()
    {
        // Inicializa el _myTransform.
        _myTransform = transform;
    }
}