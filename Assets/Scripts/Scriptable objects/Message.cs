using Scriptable_objects;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;

[CreateAssetMenu(menuName = "Scriptable objects/Message")]

public class Message : ScriptableObject
{
    public Autor Autor;
    public TMP_FontAsset Font;
    public string Text;
    public bool isInteracrable;

}