using System.Collections;
using System.Collections.Generic;
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
        BulletMovement _bullet = collision.collider.GetComponent<BulletMovement>();

        //Comprobamos si el objeto que está chocando es una bala...
        if (_bullet != null)
        {
            // Obtenemos la normal del primer punto de contacto de la colisión.
            Vector3 _normal = collision.contacts[0].normal;

            // Calculamos el vector perpendicular a la normal y al eje Z (forward).
            Vector3 wall = Vector3.Cross(Vector3.forward, _normal);

            // Calculamos el producto escalar entre el vector wall y la dirección de la bala.
            float cWall = Vector3.Dot(wall, _bullet.Speed.normalized);

            // Calculamos el producto escalar entre la dirección de la bala y la normal.
            float cNormal = Vector3.Dot(_bullet.Speed.normalized, _normal);

            // Calculamos el vector de reflexión.
            Vector3 reflexion1 = cWall * wall + -(cNormal * _normal);
            
            // Establecemos que la nueva dirección sea el vector reflexión.
            _bullet.SetDirection(reflexion1.normalized); // w
        }
    }
    #endregion
}
