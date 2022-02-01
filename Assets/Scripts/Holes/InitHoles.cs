using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClawBrawl
{
    public class InitHoles : MonoBehaviour
    {
        // For Gizmos
        private float radius;
        [SerializeField] private GameObject radiusObj;
        [SerializeField] private bool showBoxGizmo;

        [SerializeField] private GameObject holePrefab;
        [SerializeField] private int maxPoints;
        [Range(0, 1), SerializeField] public float chanceDecoy;

        private void Start()
        {
            SpawnNHoles(maxPoints);
            radius = Vector3.Distance(GameObject.FindGameObjectWithTag("Radius").transform.position, Vector3.zero);
        }

        private void OnDrawGizmos()
        {
            if (!showBoxGizmo) return;

            Gizmos.color = new Color(1, 1, 0, 0.5f);
            Gizmos.DrawWireSphere(
                Vector3.zero,
                Vector3.Distance(radiusObj.transform.position, Vector3.zero)
            );
        }

        private void SpawnNHoles(int n)
        {
            for (int i = 0; i < n; i++)
                SpawnHole();
        }

        private void SpawnHole()
        {
            GameObject hole = GameObject.Instantiate(holePrefab, Vector3.zero, Quaternion.identity);
            hole.transform.SetParent(transform);
        }
    }
}
