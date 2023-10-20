using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class ReboundComponent : MonoBehaviour
{
    #region methods
    /// <summary>
    /// This method detects if the collided object is a bullet. Use duck typing!
    /// If it is a bullet, the movement direction is set to fake a rebound on the surface:
    /// Normal, tangent, dot product and cross product will be required to accomplish this
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("col");
        //Comprobar si esto está bien
        BulletMovement _bullet = collision.collider.GetComponent<BulletMovement>();

        if(_bullet != null)
        {
            //Calcular el 
            //¿Cuál es la nueva dirección??
            Vector3 normal = new Vector3(_bullet.transform.position.y, _bullet.transform.position.x, 0);
            Vector3 vector = new Vector3(_bullet.transform.position.x, _bullet.transform.position.y, 0);
            Vector3 _direction = vector - 2 * (vector.x * normal.x + vector.y * normal.y) * normal;
            _bullet.SetDirection(_direction);
        }
    }
    #endregion
}