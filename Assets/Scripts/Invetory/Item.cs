using UnityEngine;

public enum SlotTag { None, Head, Hands, Feet}

[CreateAssetMenu(menuName ="E.P.I.")]
public class Item : ScriptableObject
{
    public Sprite sprite;
    public string nameEquip;
    public bool equipCerto;
    public SlotTag itemTag;
    public GameObject prefab;
}
