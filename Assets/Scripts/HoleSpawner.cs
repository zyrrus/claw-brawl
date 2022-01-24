using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClawBrawl
{
    public class HoleSpawner : MonoBehaviour
    {
        [SerializeField] BoxCollider bc;
        List<Vector3> points = new List<Vector3>();

        private void Awake()
        {
            bc = GetComponent<BoxCollider>();
        }

        private void Start()
        {
            for (int i = 0; i < 10; i++)
            {
                points.Add(GenRandomVector());
            }
        }

        private Vector3 GenRandomVector()
        {
            float x = Random.Range(bc.bounds.min.x, bc.bounds.max.x);
            float z = Random.Range(bc.bounds.min.z, bc.bounds.max.z);
            return new Vector3(x, 0, z);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1, 1, 0, 0.5f);
            Gizmos.DrawCube(bc.center, bc.size);

            Gizmos.color = new Color(1, 0, 0, 0.5f);
            foreach (Vector3 point in points)
            {
                Gizmos.DrawSphere(point, 1);
            }
        }
    }
}
