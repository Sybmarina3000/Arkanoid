using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IBrush
{
    Color GetColor(int valueHP);
}
public class BrickBrush : MonoBehaviour, IBrush
{
    [SerializeField] private Color[] massColor;
    public Color GetColor(int valueHP) { return massColor[valueHP - 1]; }
}
