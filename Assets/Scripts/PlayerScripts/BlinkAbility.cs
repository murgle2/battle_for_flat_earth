using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GameCompany.BFE
{
    public class BlinkAbility : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D rb;
        [SerializeField]
        private float distance;
        [SerializeField]
        private float coolDown;


        private float lastBlink = -1;


        private Vector2 pos1;
        private Vector2 pos2;

        private void Start()
        {
            //GameObject button = GetComponent<Butt>

        }

        public void Blink()
        {
            if (Time.time >= coolDown + lastBlink || lastBlink == -1)
            {
                pos1 = rb.position;
                StartCoroutine("Wait");

                lastBlink = Time.time;
            }
        }

        private IEnumerator Wait()
        {
            //waits small amount of time, gets second location and calculates direction. Direction * distance + old position = new position
            yield return new WaitForSeconds(0.01f);
            pos2 = rb.position;
            Vector2 direction = pos2 - pos1;
            direction.Normalize();
            rb.position += direction * distance;

        }
    }
}
