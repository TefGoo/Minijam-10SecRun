using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles
{
    public class opencloseDoor : MonoBehaviour
    {
        public Animator openandclose;
        public bool open;
        public Transform Player;
        public GameObject indicatorSprite; // Reference to the 2D sprite

        void Start()
        {
            open = false;
            SetIndicatorSpriteVisibility(!open); // Initially hide the sprite
        }

        void OnMouseOver()
        {
            if (Player)
            {
                float dist = Vector3.Distance(Player.position, transform.position);
                if (dist < 15)
                {
                    if (!open)
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            StartCoroutine(opening());
                        }
                    }
                    else
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            StartCoroutine(closing());
                        }
                    }
                }
            }
        }

        IEnumerator opening()
        {
            print("You are opening the door");
            openandclose.Play("Opening");
            open = true;
            SetIndicatorSpriteVisibility(!open); // Hide the sprite when the door is open
            yield return new WaitForSeconds(.5f);
        }

        IEnumerator closing()
        {
            print("You are closing the door");
            openandclose.Play("Closing");
            open = false;
            SetIndicatorSpriteVisibility(!open); // Show the sprite when the door is closed
            yield return new WaitForSeconds(.5f);
        }

        void SetIndicatorSpriteVisibility(bool visible)
        {
            if (indicatorSprite != null)
            {
                indicatorSprite.SetActive(visible);
            }
        }
    }
}
