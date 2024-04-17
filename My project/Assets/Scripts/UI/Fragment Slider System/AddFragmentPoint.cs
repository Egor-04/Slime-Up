using UnityEngine;

public class AddFragmentPoint : MonoBehaviour
{
    [Header("Balance Name")]
    [SerializeField] private string _fragmentBalanceName = "ALL_FRAGMENTS";
    
    [Header("Options")]
    [SerializeField] private int AddFragmentCount = 40;
    [SerializeField] private FragmentSlider FragmentSliderScript;

    [Header("Fragment Balance")]
    [SerializeField] private GetSavedKeyValue _getSavedKeyValue;

    private void Start()
    {
        AddFragmentCount = FragmentSliderScript.GetPointsInOneFragment();
        Debug.Log(AddFragmentCount);
    }

    public void AddFragmentPoints(FragmentSlider fragmentSlider)
    {
        if (PlayerPrefs.GetInt(_fragmentBalanceName) >= FragmentSliderScript.GetPointsInOneFragment())
        {
            fragmentSlider.CurrentFragmentsCount += AddFragmentCount;
            int currentFragmentsCount = PlayerPrefs.GetInt(_fragmentBalanceName) - AddFragmentCount;
            PlayerPrefs.SetInt(_fragmentBalanceName, currentFragmentsCount);

            int currentFragmentsCountInSlider = PlayerPrefs.GetInt(FragmentSliderScript._allSavedFragmentSliderCountKey) + AddFragmentCount;
            PlayerPrefs.SetInt(FragmentSliderScript._allSavedFragmentSliderCountKey, currentFragmentsCountInSlider);
            _getSavedKeyValue.UpdateBalance();
        }
    }

    public void DeleteFragmentPoints(FragmentSlider fragmentSlider)
    {
        fragmentSlider.CurrentFragmentsCount -= AddFragmentCount;
    }
}
