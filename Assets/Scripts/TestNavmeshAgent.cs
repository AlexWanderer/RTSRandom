using UnityEngine;
using System.Collections;

public class TestNavmeshAgent : MonoBehaviour
{

    public Transform goal;

    void Start()
    {

    }

    void Update()
    {
        if (Time.frameCount % 100 == 0)
        {
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            agent.SetDestination(goal.position);
        }
    }
}
