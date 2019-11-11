using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCompany.BFE
{
    public class BotSmallDamage : MonoBehaviour
    {
        [SerializeField]
        private int damage;

        private float distance;
        private void OnTriggerEnter2D(Collider2D hitInfo)
        {
            HealthBar healthBar = hitInfo.gameObject.GetComponent<HealthBar>();
            CircleCollider2D circleCollider = hitInfo.GetComponent<CircleCollider2D>();

            //only does damage if it touches a player
            //if (hitInfo.tag == "Player")
            //{
            //    if (healthBar != null)
            //    {
            //        healthBar.Takedamage(damage);
            //    }
            //}



            distance = Vector2.Distance(gameObject.transform.position, hitInfo.transform.position);

            //also checks distance to make sure we are using the inside circleCollider
            if (hitInfo.tag == "Player" && healthBar != null && distance <= circleCollider.radius + 1)
            {
                healthBar.Takedamage(damage);
                Destroy(gameObject);
            }

        }
    }
}
