using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GameCompany.BFE
{
    public class ShootJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
    {
        public float Horizontal { get { return input.x; } }
        public float Vertical { get { return input.y; } }
        public Vector2 Direction { get { return new Vector2(Horizontal, Vertical); } }


        private Vector2 input = Vector2.zero;
        private Canvas canvas;
        private Camera cam;
        [SerializeField]
        protected RectTransform background = null;

        private void Start()
        {
            canvas = GetComponentInParent<Canvas>();
            Vector2 center = new Vector2(0.5f, 0.5f);
            background.pivot = center;
        }


        public virtual void OnPointerDown(PointerEventData eventData)
        {
            OnDrag(eventData);
        }

        public void OnDrag(PointerEventData eventData)
        {
            
            cam = null;
            if (canvas.renderMode == RenderMode.ScreenSpaceCamera)
            {
                Debug.Log("canvas render mode thing worked");
                cam = canvas.worldCamera;
            }
            Vector2 position = RectTransformUtility.WorldToScreenPoint(cam, background.position);
            Vector2 radius = background.sizeDelta / 2;
            input = (eventData.position - position) / (radius * canvas.scaleFactor);
            //HandleInput(input.magnitude, input.normalized, radius, cam);
            //handle.anchoredPosition = input * radius * handleRange;
        }

        public virtual void OnPointerUp(PointerEventData eventData)
        {
            input = Vector2.zero;
            //handle.anchoredPosition = Vector2.zero;
        }

    }
}
