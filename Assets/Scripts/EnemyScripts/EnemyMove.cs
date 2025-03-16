using System;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    CharacterController controller;

    [SerializeField] private float moveSpeed = 5f;

    private void OnEnable()
    {
        GameEvents.OnEnemyFinish += OnFinishLine;
    }
    private void OnDisable()
    {
        GameEvents.OnEnemyFinish -= OnFinishLine;
    }

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        controller.Move(moveSpeed * Time.deltaTime * transform.forward);
    }

    void OnFinishLine()
    {
        Debug.Log("Lost");
        this.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            GameEvents.EnemyFinished();
        }
    }
}
