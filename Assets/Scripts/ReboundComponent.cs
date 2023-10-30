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
        BulletMovement _bullet = collision.collider.GetComponent<BulletMovement>();

        if(_bullet != null)
        {
            // ANTES DE NADA MIRAR EL CÓDIGO CON LA CHULETA DEL PROFE AL LADO.

            // Datos: d (_vector), n (_normal), n' (-_normal), t, z, pt, pn.

            // Esto funciona así: el "contacts" es el punto de colisión con el obstáculo, y "[0]" es el primer punto de contacto en un array que tiene (nada mas darle).
            // El ".normal" saca el vector normal, q es la perpendicular del punto de choque del obstáculo.
            Vector3 _normal = collision.contacts[0].normal.normalized; // n
            //Probar los debugs cuando tenemos el obstaculo en vertical para hacer bien esto

            // El vector que lleva la bala.
            Vector3 _vector = _bullet.Speed; // d

            // La dirección es w = ((n' * d) * n') + ((t * d) * t)
            //                           pn                pt

            float t = Vector3.Dot(_vector, _normal); // t = z (Vector3.forward) x n'

            Vector3 _direction = (_vector - (2 * t) * _normal).normalized;
            //                                                    ((d * n')    *    n')    +                               ((t * d) * t)


            // Según la API de Unity, "Reflect" hace esto: "Refleja un vector fuera del plano definido por una normalidad.", entonces lo que hay que darle es 
            // "vector": el vector que se va a reflejar y "normal": la normal de la superficie con respecto a la cual se va a realizar la reflexión.
            // El vector se normaliza para obtener unicamente su dirección.
            //Vector3 _direction = Vector3.Reflect(vector, normal);
            //Vector3 _direction = _vector - 2 * (Vector3.Dot(_vector, _normal) * _normal);

            // Establecemos la nueva dirección "direction".
            //Set direction editado
            //if(_normal == new Vector3(0,1,0))
            //{
            //    Debug.Log("pa abajo");
            //    _direction.y = -_direction.y;
            //}

            _bullet.SetDirection(_direction); // w.

            //// Lo del debug.
            //Debug.DrawRay(_bullet.transform.position, _vector, Color.blue,36000);
            //Debug.DrawRay(this.transform.position, _normal, Color.red, 36000);
            //Debug.DrawRay(_bullet.transform.position, _direction, Color.green, 36000);
            //Debug.Log(_normal);
        }
    }
    #endregion
}