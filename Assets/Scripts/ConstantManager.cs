using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConstantManager
{
    public readonly static Vector2 MIN_POSITION = new Vector2(-8.9f, -5f);
    public readonly static Vector2 MAX_POSITION = new Vector2(8.9f, 5f);

    public const string LOBBY_SCENE = "Main";
    public const string MAIN_SCENE = "Game";
    public const string STORY_SCENE = "DialogueTest";
}
