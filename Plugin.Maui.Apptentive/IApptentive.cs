namespace Plugin.Maui.Apptentive;

public interface IApptentive {
    void Register(ApptentiveConfiguration configuration, Action<bool> completion);

    void Engage(string Event);

    void PresentMessageCenter();
}