interface IGun
{
    float ReloadingTime { get; }
    void Shot();
    void Reload(float reloadingTime);
}
