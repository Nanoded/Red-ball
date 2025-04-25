using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MovementUIController : MonoBehaviour
{
    [SerializeField] private EventTrigger _leftTrigger;
    [SerializeField] private EventTrigger _rightTrigger;
    [SerializeField] private EventTrigger _jumpTrigger;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void OnDestroy() => CleanupTriggers();

    private void CleanupTriggers()
    {
        _leftTrigger.triggers.Clear();
        _rightTrigger.triggers.Clear();
        _jumpTrigger.triggers.Clear();
    }

    private EventTrigger.Entry GetMovementEntry(EventTriggerType triggerType, UnityAction<int> action, Vector2 direction)
    {
        EventTrigger.Entry entry = new EventTrigger.Entry
        {
            eventID = triggerType
        };
        int x = triggerType == EventTriggerType.PointerUp ? 0 : (int)direction.x;
        entry.callback.AddListener((_) => action.Invoke(x));
        return entry;
    }
    
    public void SubscribeToLeftTrigger(EventTriggerType triggerType, UnityAction<int> action)
    {
        EventTrigger.Entry entry = GetMovementEntry(triggerType, action, Vector2.left);
        _leftTrigger.triggers.Add(entry);
    }

    public void SubscribeToRightTrigger(EventTriggerType triggerType, UnityAction<int> action)
    {
        EventTrigger.Entry entry = GetMovementEntry(triggerType, action, Vector2.right);
        _rightTrigger.triggers.Add(entry);
    }

    public void SubscribeToJumpTrigger(EventTriggerType triggerType, UnityAction action)
    {
        EventTrigger.Entry entry = new EventTrigger.Entry
        {
            eventID = triggerType
        };
        entry.callback.AddListener((_) => action.Invoke());
        _jumpTrigger.triggers.Add(entry);
    }
}
