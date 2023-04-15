using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles
{
    public class opencloseWindowApt : MonoBehaviour
    {
        public Animator openandclosewindow;
        public bool open;
        public Transform Player;

        public AudioClip openSound; // sound to play when window is opened
        public AudioClip closeSound; // sound to play when window is closed
        private AudioSource audioSource; // reference to the AudioSource component

        void Start()
        {
            open = true;
            audioSource = GetComponent<AudioSource>(); // get the AudioSource component
        }

        void OnMouseOver()
        {
            if (Player)
            {
                float dist = Vector3.Distance(Player.position, transform.position);
                if (dist < 15)
                {
                    if (open == false)
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            StartCoroutine(opening());
                        }
                    }
                    else
                    {
                        if (open == true)
                        {
                            if (Input.GetMouseButtonDown(0))
                            {
                                StartCoroutine(closing());
                            }
                        }
                    }
                }
            }
        }

        IEnumerator opening()
        {
            print("you are opening the Window");
            openandclosewindow.Play("Openingwindow");
            open = true;
            if (openSound != null && audioSource != null)
            {
                audioSource.clip = openSound;
                audioSource.Play();
            }
            yield return new WaitForSeconds(.5f);
        }

        IEnumerator closing()
        {
            print("you are closing the Window");
            openandclosewindow.Play("Closingwindow");
            open = false;
            if (closeSound != null && audioSource != null)
            {
                audioSource.clip = closeSound;
                audioSource.Play();
            }
            yield return new WaitForSeconds(.5f);
        }
    }
}
