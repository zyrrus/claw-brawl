using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClawBrawl
{
    class Leg
    {
        public static Transform body;

        public Transform transform;
        public Ray ray;

        public Leg(Transform t)
        {
            this.transform = t;

            float footSpacing = transform.position.x - body.position.x;
            this.ray = new Ray(body.position + (body.right * footSpacing), Vector3.down);
        }
    }

    public class LegIKController : MonoBehaviour
    {
        [SerializeField] private List<Leg> legs = new List<Leg>();
        [SerializeField] private Transform body;

        private void Awake()
        {
            Leg.body = body;
        }

        private void Start()
        {
            foreach (Transform child in transform)
            {
                legs.Add(new Leg(child));
            }
        }

        private void Update()
        {
            foreach (Leg leg in legs)
            {
                if (Physics.Raycast(leg.ray, out RaycastHit info, 10, LayerMask.GetMask("Terrain")))
                {
                    leg.transform.position = info.point;
                }
                // Transform target = leg.GetChild(0).transform;
                // RaycastHit info;
                // Vector3 root = target.position;
                // root.y += 10;
                // if (Physics.Raycast(root, Vector3.down, out info))
                // {
                // }

            }
        }
    }
}
