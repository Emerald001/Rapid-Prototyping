using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventType {
    OnPlayerDamaged = 0,
}

public static class EventManager<T> {
    private static Dictionary<EventType, System.Action<T>> reactions = new Dictionary<EventType, System.Action<T>>();

    public static void RaiseEvent(EventType type, T input) {
        if (reactions.ContainsKey(type)) {
            reactions[type]?.Invoke(input);
        }
    }
    public static void AddListener(EventType type, System.Action<T> action) {
        if (reactions.ContainsKey(type)) {
            reactions[type] += action;
        }
        else {
            reactions.Add(type, action);
        }
    }
    public static void RemoveListener(EventType type, System.Action<T> action) {
        if (reactions.ContainsKey(type)) {
            reactions[type] -= action;
        }
    }
}