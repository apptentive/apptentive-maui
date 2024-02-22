using System;

namespace Plugin.Maui.Apptentive;

#nullable enable

    /// <summary>
    /// This class wraps the native ApptentiveConfiguration class and adds
    /// DistributionName and DistributionVersion on top of the basic configuration
    /// </summary>
public class ApptentiveConfiguration
{
    public readonly string ApptentiveKey;
    public readonly string ApptentiveSignature;
    public ApptentiveLogLevel LogLevel;
    public bool ShouldSanitizeLogMessages;
    public bool ShouldEncryptStorage;
    public long RatingInteractionThrottleLength;
    public string? CustomAppStoreURL;

    public ApptentiveConfiguration(string ApptentiveKey, string ApptentiveSignature)
    {
        if (string.IsNullOrEmpty(ApptentiveKey))
        {
            throw new ArgumentException("Apptentive key is null or empty");
        }

        if (string.IsNullOrEmpty(ApptentiveSignature))
        {
            throw new ArgumentException("Apptentive signature is null or empty");
        }

        this.ApptentiveKey = ApptentiveKey;
        this.ApptentiveSignature = ApptentiveSignature;

        LogLevel = ApptentiveLogLevel.Info;
        ShouldSanitizeLogMessages = !System.Diagnostics.Debugger.IsAttached;
        ShouldEncryptStorage = false;      
        RatingInteractionThrottleLength = 7 * 24 * 60 * 60 * 1000;
    }

    public string DistributionName
    {
        get { return "Maui"; }
    }

    public string DistributionVersion
    {
        get { return GetType()?.Assembly?.GetName()?.Version?.ToString(3) ?? "Unknown"; }
    }
}

public enum ApptentiveLogLevel : ulong
{
    Undefined = 0,
    Crit = 1,
    Error = 2,
    Warn = 3,
    Info = 4,
    Debug = 5,
    Verbose = 6
}
