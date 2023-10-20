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
        //NO DETECTA LA COLISION!!!
        Debug.Log("col");
        //Comprobar si esto está bien
        BulletMovement _bullet = collision.collider.GetComponent<BulletMovement>();

        if(_bullet != null)
        {

        
            // Esto funciona así: el "contacts" es el punto de colisión con el obstáculo, y "[0]" es el primer punto de contacto en un array que tiene (nada mas darle).
            // El ".normal" saca el vector normal, q es la perpendicular del punto de choque del obstáculo.
            Vector3 normal = collision.contacts[0].normal;

            // El vector que lleva la bala.
            Vector3 vector = new Vector3(_bullet.transform.position.x, _bullet.transform.position.y, 0);

            // Según la API de Unity, "Reflect" hace esto: "Refleja un vector fuera del plano definido por una normalidad.", entonces lo que hay que darle es 
            // "vector": el vector que se va a reflejar y "normal": la normal de la superficie con respecto a la cual se va a realizar la reflexión.
            // El vector se normaliza para obtener unicamente su dirección.
            Vector3 _direction = Vector3.Reflect(vector, normal).normalized; 

            // Establecemos la nueva dirección "direction".
            _bullet.SetDirection(_direction);
        }
    }
    #endregion
}