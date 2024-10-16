using UnityEngine;
using UnityEngine.UI;

public class EnemiesDestroyedView : MonoBehaviour
{
    [SerializeField] private Text _text;

    public void UpdateView(int count) => _text.text = $"Enemies Destroyed: {count}";
}