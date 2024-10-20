using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AttractComponent : MonoBehaviour
{
    #region parameters
    /// <summary>
    /// Parameter to regulate the attraction speed of the attraction area
    /// </summary>

    [SerializeField]
    private float _attraction;
    #endregion

    #region references

    /// <summary>
    /// Reference to own transform
    /// </summary>
    private Transform _myTransform;
    #endregion

    /// <summary>
    /// Called when an object stays inside the trigger area.
    /// We will evalate if collided object is a Bullet. Use duck typing!
    /// If it is a bullet, add attraction speed to the speed of the bullet.
    /// </summary>
    /// <param name="collision">Collided object</param>
    private void OnTriggerStay2D(Collider2D collision)
    {
        BulletMovement _bullet = collision.GetComponent<BulletMovement>();

        // Si el objeto es una bala...
        if (_bullet != null)
        {
            // Calculamos la direcci�n desde la bala hasta el centro del �rea de atracci�n.
            Vector3 direction = (_myTransform.position - _bullet.transform.position).normalized; // Vector direcci�n = centro �rea - posici�n bala.
                                                                                                 // Se normaliza para que la magnitud sea 1.

            // A�adimos la velocidad de atracci�n a la velocidad actual de la bala.
            _bullet.SetDirection(_bullet.Speed + direction * _attraction); // Al sumar la direcci�n a la velocida de bala se est� cambiando la trayectoria
                                                                           // de la bala para que se mueva hacia el centro del �rea.
                                                                           // Se multiplica por la atracci�n para determinar con CU�NTA fuerza se atrae al centro.
        }
    }
    /// <summary>
    /// Start is called before the first frame update.
    /// Set reference to own transform
    /// </summary>
    void Start()
    {
        _myTransform = transform;
    }
}