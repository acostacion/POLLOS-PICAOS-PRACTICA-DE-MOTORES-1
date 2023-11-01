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

        //Comprobamos si el objeto que está chocando es una bala
        if (_bullet != null)
        {
            Debug.Log("Colisiona");
            Vector3 _normal = collision.contacts[0].normal;  
            //Vector3 _Speed = _bullet.transform.position;

            #region Metodo 1
            //Vector3 z = Vector3.forward;

            ////Debug.Log("n: " + _normal + " _speed: " + _direccion);
            //Vector3 t = Vector3.Cross(z, -_normal).normalized;

            //Vector3 pn = Vector3.Dot(-_normal, _direccion) * -_normal;    //Puede ser simplemente la normal negada
            //Vector3 pt = Vector3.Dot(t, _direccion) * t;

            //Vector3 w = pn + pt;

            //Vector3 _direction = (_vector - (2 * t) * _normal).normalized; // ((d * n')    *    n')+((t * d) * t)
            #endregion

            #region Método 2
            //Vector3 w = _speed - Vector3.Dot(2 * Vector3.Dot(_speed, _normal), _normal) ;
            #endregion

            #region Metodo 3
            Vector3 wall = Vector3.Cross(Vector3.forward, _normal);

            float cWall = Vector3.Dot(wall, _bullet.Speed.normalized);
            float cNormal = Vector3.Dot(_bullet.Speed.normalized, _normal);

            Vector3 reflexion1 = cWall * wall + -(cNormal * _normal);


            #endregion

            //Debug.Log(_Speed);

            _bullet.SetDirection(reflexion1.normalized); // w.

            Debug.DrawRay(this.transform.position, _normal, Color.red, 36000);
        }
    }
    #endregion
}
