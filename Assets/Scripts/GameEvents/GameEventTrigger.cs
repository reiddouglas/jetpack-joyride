using UnityEngine;

public class GameEventTrigger : MonoBehaviour
{
    [SerializeField] private GameEvent OnTriggerEnterEvent;
    [SerializeField] private GameEvent OnTriggerStayEvent;
    [SerializeField] private GameEvent OnTriggerExitEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnTriggerEnterEvent?.Raise();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        OnTriggerStayEvent?.Raise();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        OnTriggerExitEvent?.Raise();
    }
}
