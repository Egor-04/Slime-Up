using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class FragmentSlider : MonoBehaviour
{
    [Header("Fragment Slider Balance")]
    public string _allSavedFragmentSliderCountKey = "ALL_SAVED_FRAGMENTS_IN_SLIDER";
    
    [Header("Points")]
    public int CurrentFragmentsCount;
    [SerializeField] private int _maxFragmentsCount = 1000;
    [SerializeField] private int _pointsInOneFragment = 40;

    [Header("Prizes")]
    [SerializeField] private int _prizeNumber;
    [SerializeField] private PrizeSkin[] _allPrizeSkins;

    [Header("UI")]
    [SerializeField] private TMP_Text _currentPointsText;
    [SerializeField] private TMP_Text _maxPointsText;

    [Header("Fragments")]
    [SerializeField] private Image[] _fragmentsArray;

    public class PrizeSkin
    {
        [Header("Prize Skins")]
        public string _skinKeyName = "FIRST_PRIZE_SKIN";

        public void GetSkin()
        {
            PlayerPrefs.GetInt(_skinKeyName, 1);
        }
    }

    private void Awake()
    {
        _pointsInOneFragment = _maxFragmentsCount / _fragmentsArray.Length;
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey(_allSavedFragmentSliderCountKey))
        {
            CurrentFragmentsCount = PlayerPrefs.GetInt(_allSavedFragmentSliderCountKey);
        }
        else
        {
            PlayerPrefs.SetInt(_allSavedFragmentSliderCountKey, CurrentFragmentsCount);
        }
    }

    private void Update()
    {
        CurrentFragmentsCount = Mathf.Clamp(CurrentFragmentsCount, 0, _maxFragmentsCount);

        _maxPointsText.text = _maxFragmentsCount.ToString();
        _currentPointsText.text = CurrentFragmentsCount.ToString();

        for (int i = 0; i < _fragmentsArray.Length; i++)
        {
            _fragmentsArray[i].enabled = !DisplayFragmentPoints(CurrentFragmentsCount, i);
        }
    }

    private void GivePrizeSkin()
    {
        if (CurrentFragmentsCount == _maxFragmentsCount)
        {
            _allPrizeSkins[_prizeNumber].GetSkin();
        }
    }

    private bool DisplayFragmentPoints(int fragmentCount, int fragmentNumber)
    {
        return ((fragmentCount / _pointsInOneFragment) <= fragmentNumber);
    }

    public int GetPointsInOneFragment()
    {
        return _pointsInOneFragment;
    }
}