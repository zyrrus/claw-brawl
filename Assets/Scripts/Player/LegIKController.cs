using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClawBrawl
{
    class Leg
    {
        public static Transform body;

        public Transform transform;
        public Vector3 relativeOriginalPos;
        public Vector3 lastPos;
        private float distanceToBody;
        private float tolerance = 0.4f;
        public Ray ray;

        public Leg(Transform t)
        {
            this.transform = t;

            this.lastPos = transform.position;
            this.relativeOriginalPos = body.position - transform.position;

            this.distanceToBody = GetDistToBody(transform.position);
        }

        public bool IsBalanced()
        {
            float currentDist = GetDistToBody(transform.position);
            return distanceToBody - (tolerance / 2) <= currentDist && currentDist <= distanceToBody + (tolerance / 2);
        }

        private float GetDistToBody(Vector3 b)
        {
            return Vector3.Distance(body.position, b);
        }

        private void Step()
        {
            relativeOriginalPos.y = 0;
            Vector3 nextStep = Quaternion.LookRotation(body.forward, body.up) * -relativeOriginalPos;

            transform.position = body.position + nextStep;
        }

        public void Update()
        {
            if (IsBalanced())
                // Stick to the ground
                transform.position = lastPos;
            else Step();

            lastPos = transform.position;
        }

        public void DrawGizmos()
        {
            Gizmos.color = IsBalanced() ? Color.green : Color.red;
            Gizmos.DrawWireSphere(transform.position, 0.2f);

            Gizmos.color = Color.black;
            Gizmos.DrawSphere(body.position + Quaternion.LookRotation(body.forward, body.up) * relativeOriginalPos, 0.2f);
        }
    }

    public class LegIKController : MonoBehaviour
    {
        [SerializeField] private List<Leg> legs = new List<Leg>();
        [SerializeField] private Transform body;
        private Vector3 lastBodyPos;

        private void Awake()
        {
            Leg.body = body;
        }

        private void Start()
        {
            lastBodyPos = body.transform.position;

            foreach (Transform child in transform)
            {
                legs.Add(new Leg(child.GetChild(0)));
            }
        }

        private void Update()
        {
            foreach (Leg leg in legs)
            {
                leg.Update();
            }
        }

        private void OnDrawGizmos()
        {
            foreach (Leg leg in legs)
            {
                leg.DrawGizmos();
            }
        }
    }
}
