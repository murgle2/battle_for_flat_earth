using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


namespace GameCompany.BFE
{
    public class Weapon : MonoBehaviour
    {

        public Transform firePoint;
        public GameObject projectilePrefab;

        [SerializeField]
        private float projectileForce;
        [SerializeField]
        private float coolDown;

        private float lastShot = -1;
        private ShootJoystick shootJoystick;
        private void Start()
        {
            shootJoystick = FindObjectOfType<ShootJoystick>();

        }

        private void Update()
        {
            if (shootJoystick.Direction != Vector2.zero)
            {
                Shoot();
            }
        }

        void Shoot()
        {
            // Shooting and cooldown
            if (Time.time >= coolDown + lastShot || lastShot == -1)
            {
                //the instantiation is immediately saved to an object so we don't lose it
                GameObject theProjectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
                Rigidbody2D rb = theProjectile.GetComponent<Rigidbody2D>();
                //controller direction used for velocity of projectile
                rb.AddForce(shootJoystick.Direction.normalized * projectileForce, ForceMode2D.Impulse);

                lastShot = Time.time;
            }

        }
    }
}
