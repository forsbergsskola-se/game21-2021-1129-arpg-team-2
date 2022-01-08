using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BaseQuest : ScriptableObject
{
    [SerializeField] private string questName;
    public string QuestName => questName;

    [TextArea(15, 20)]
    [SerializeField] private string questDescription;
    public string QuestDescription => questDescription;

    [SerializeField] private List<QuestTodo> questTodoList;
    public List<QuestTodo> QuestTodoList => questTodoList;

    [SerializeField] private QuestStatus questStatus = QuestStatus.Inactive;
    public QuestStatus QuestStatus => questStatus;
}

public enum QuestType
{
    Main,
    Side
}

public enum SubQuestType
{
    Collect,
    Kill
}

public enum QuestStatus
{
    Inactive,
    Active,
    Complete
}

[Serializable]
public class QuestTodo
{
    [SerializeField] private string description;
    public string Description => description;

    [SerializeField] private bool isComplete;
    public bool IsComplete { get => isComplete; set => isComplete = value; }
}
