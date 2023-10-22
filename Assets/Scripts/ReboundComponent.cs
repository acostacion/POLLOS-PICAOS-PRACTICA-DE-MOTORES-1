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
            Debug.Log("Reconoce que es una bala");
        
            // Esto funciona así: el "contacts" es el punto de colisión con el obstáculo, y "[0]" es el primer punto de contacto en un array que tiene (nada mas darle).
            // El ".normal" saca el vector normal, q es la perpendicular del punto de choque del obstáculo.
            Vector3 normal = collision.contacts[0].normal;

            // El vector que lleva la bala. *Esto parece que va bien
            Vector3 vector = new Vector3(_bullet.transform.position.x, _bullet.transform.position.y, 0);
            Debug.Log("Vector y normal");
            Debug.Log(vector);
            Debug.Log(normal);  //Da siempre el vector (1,0,0)

            // Según la API de Unity, "Reflect" hace esto: "Refleja un vector fuera del plano definido por una normalidad.", entonces lo que hay que darle es 
            // "vector": el vector que se va a reflejar y "normal": la normal de la superficie con respecto a la cual se va a realizar la reflexión.
            // El vector se normaliza para obtener unicamente su dirección.
            //Vector3 _direction = Vector3.Reflect(vector, normal);
            Vector3 _direction = vector - 2 * (vector * normal) * normal;
            Debug.Log("NuevaDirección");
            Debug.Log(_direction);

            // Establecemos la nueva dirección "direction".
            _bullet.SetDirection(_direction);
        }
    }
    #endregion
}