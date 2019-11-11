using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCompany.BFE
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField]
        private int damage;
        [SerializeField]
        private float timeOut;

        private void Start()
        {
            StartCoroutine("Wait");
        }

        private void OnTriggerEnter2D(Collider2D hitInfo)
        {
            HealthBar healthBar = hitInfo.gameObject.GetComponent<HealthBar>();

            //prevents from damaging yourself, as the projectile spawns in your collider
            //need to update when targeting other players
            if (hitInfo.tag != "Player" && hitInfo.tag != "Projectile")
            {
                Destroy(gameObject);
                if (healthBar != null)
                {
                    healthBar.Takedamage(damage);
                }
            }
        }

        private IEnumerator Wait()
        {
            yield return new WaitForSeconds(timeOut);
            Destroy(gameObject);
        }
    }
}
