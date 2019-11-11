using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


namespace GameCompany.BFE
{
    public class AggroScript : MonoBehaviour
    {

        //sets scripts of the bot object to follow the player
        private void OnTriggerEnter2D(Collider2D collision)
        {
            AIDestinationSetter aiDestinationSetter = collision.GetComponent<AIDestinationSetter>();
            BotSmallMovement botSmallMovement = collision.GetComponent<BotSmallMovement>();
            AIPath aiPath = collision.GetComponent<AIPath>();

            if (aiDestinationSetter != null && botSmallMovement != null && aiPath != null)
            {
                aiPath.enabled = true;
                aiDestinationSetter.target = gameObject.transform;
                botSmallMovement.hasTarget = true;

            }
        }

        //sets scripts of the bot object to stop following the player
        private void OnTriggerExit2D(Collider2D collision)
        {
            AIDestinationSetter aiDestinationSetter = collision.GetComponent<AIDestinationSetter>();
            BotSmallMovement botSmallMovement = collision.GetComponent<BotSmallMovement>();
            AIPath aiPath = collision.GetComponent<AIPath>();

            if (aiDestinationSetter != null && botSmallMovement != null && aiPath != null)
            {
                aiPath.enabled = false;
                aiDestinationSetter.target = null;
                botSmallMovement.hasTarget = false;
            }
        }
    }
}
