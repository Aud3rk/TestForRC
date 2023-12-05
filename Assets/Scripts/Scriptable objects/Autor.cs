using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(menuName = "Scriptable objects/Autor")]
public class Autor : ScriptableObject
{
    public string Id;
    public string Name;
    public Color Color;
    public Sprite Icon;
}