using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCompany.BFE
{
    public class SpawnScript : MonoBehaviour
    {
        public GameObject botSmallAi;
        public float spawnTime;
        private float spawnTimer;
        void Start()
        {
            spawnTimer = spawnTime;
        }

        void Update()
        {

            //makes a bot at the spawnTime interval
            if (spawnTimer <= 0)
            {
                Instantiate(botSmallAi);
                spawnTimer = spawnTime;
            }
            else
            {
                spawnTimer -= Time.deltaTime;
            }
        }
    }
}
