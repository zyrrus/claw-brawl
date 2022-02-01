using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ClawBrawl
{
    public class IconCooldown : MonoBehaviour
    {
        private Image image;
        [SerializeField] private Color originalColor;
        [SerializeField] private Color dimmedColor;

        private void Awake()
        {
            image = GetComponent<Image>();
        }

        private void Start()
        {
            originalColor = image.color;

            float gray = originalColor.grayscale;
            dimmedColor = new Color(gray, gray, gray);
        }

        public void Dim()
        {
            image.color = dimmedColor;
        }

        public void Color()
        {
            image.color = originalColor;
        }
    }
}
