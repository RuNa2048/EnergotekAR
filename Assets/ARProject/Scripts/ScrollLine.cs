using UnityEngine;

public class ScrollLine : MonoBehaviour
{
    private WindowChanger _windowChanger;
    private ModelCard _leftCard;
    private ModelCard _rightCard;
    
    public void Init(ModelCard left, ModelCard right, WindowChanger menu)
    {
        _windowChanger = menu;

        _leftCard = Instantiate(left, transform);
        _rightCard = Instantiate(right, transform);

        _leftCard.OnClicked += _windowChanger.LaunchModelViewer;
        _rightCard.OnClicked += _windowChanger.LaunchModelViewer;
    }

    private void OnDisable()
    {
        _leftCard.OnClicked -= _windowChanger.LaunchModelViewer;
        _rightCard.OnClicked -= _windowChanger.LaunchModelViewer;
    }
}
