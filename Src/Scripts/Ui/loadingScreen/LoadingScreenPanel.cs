using AcidUtilities;

namespace Game.Scripts.Ui.LoadingScreen;

public partial class LoadingScreenPanel : LoadingScreen
{
    private bool IsLoaded { get; set; }
    private bool IsLoading { get; set; }

    private void FadeIn()
    {
        L_AnimationPlayer.Instance.Play("FadeIn");
    }
    
    private void FadeOut()
    {
        L_AnimationPlayer.Instance.PlayBackwards("FadeIn");
    }

    public void Load(AcidLoader loader)
    {
        if (IsLoaded || IsLoading) return;
        IsLoading = true;

        loader.OnProgressChanged += f =>
        {
            S_ProgressBar.Instance.Value = f;
        };
        
        loader.OnAllLoaded += () =>
        {
            IsLoaded = true;
            IsLoading = false;
            Destroy();
        };
        
        loader.LoadResources();
    }
}
