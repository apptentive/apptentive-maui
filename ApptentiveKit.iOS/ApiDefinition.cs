using System;
using Foundation;
using ObjCRuntime;
using UIKit;
using UserNotifications;

#nullable enable

namespace ApptentiveKit.iOS
{
	// @interface ApptentiveNavigationController : UINavigationController
	[BaseType(typeof(UINavigationController), Name = "_TtC13ApptentiveKit30ApptentiveNavigationController")]
	interface ApptentiveNavigationController
	{
	}

	// @interface Apptentive : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC13ApptentiveKit10Apptentive")]
	[DisableDefaultCtor]
	interface Apptentive : IUNUserNotificationCenterDelegate
	{
		// @property (readonly, nonatomic, strong, class) Apptentive * _Nonnull shared;
		[Static]
		[Export ("shared", ArgumentSemantic.Strong)]
		Apptentive Shared { get; }

		// @property (nonatomic) enum UITheme theme;
		[Export ("theme", ArgumentSemantic.Assign)]
		UITheme Theme { get; set; }

		// -(void)registerWithKey:(NSString * _Nonnull)key signature:(NSString * _Nonnull)signature completion:(void (^ _Nullable)(BOOL))completion;
		[Export("registerWithConfiguration:completion:")]
		void Register(ApptentiveConfiguration configuration, [NullAllowed] Action<bool> completion);

		// -(void)engage:(NSString * _Nonnull)event fromViewController:(UIViewController * _Nullable)viewController;
		[Export("engage:fromViewController:")]
		void Engage(string @event, [NullAllowed] UIViewController viewController);

		// -(void)engage:(NSString * _Nonnull)event fromViewController:(UIViewController * _Nullable)viewController completion:(void (^ _Nullable)(BOOL))completion;
		[Export("engage:fromViewController:completion:")]
		void Engage(string @event, [NullAllowed] UIViewController viewController, [NullAllowed] Action<bool> completion);

		// -(void)engage:(NSString * _Nonnull)event withCustomData:(NSDictionary * _Nullable)customData fromViewController:(UIViewController * _Nullable)viewController;
		[Export("engage:withCustomData:fromViewController:")]
		void Engage(string @event, [NullAllowed] NSDictionary customData, [NullAllowed] UIViewController viewController);

		// -(void)engage:(NSString * _Nonnull)event withCustomData:(NSDictionary * _Nullable)customData fromViewController:(UIViewController * _Nullable)viewController completion:(void (^ _Nullable)(BOOL))completion;
		[Export("engage:withCustomData:fromViewController:completion:")]
		void Engage(string @event, [NullAllowed] NSDictionary customData, [NullAllowed] UIViewController viewController, [NullAllowed] Action<bool> completion);

		// -(void)queryCanShowInteractionForEvent:(NSString * _Nonnull)event completion:(void (^ _Nonnull)(BOOL))completion;
		[Export("queryCanShowInteractionForEvent:completion:")]
		void QueryCanShowInteraction(string @event, Action<bool> completion);

		// - (void)queryCanShowMessageCenterWithCompletion:(void (^ _Nonnull)(BOOL))completion SWIFT_DEPRECATED_MSG("This feature is not implemented and will always result in false.");
		[Export("queryCanShowMessageCenterWithCompletion:")]
		void QueryCanShowMessageCenter(Action<bool> completion);

		// -(void)presentMessageCenterFromViewController:(UIViewController * _Nullable)viewController;
		[Export("presentMessageCenterFromViewController:")]
		void PresentMessageCenter([NullAllowed] UIViewController viewController);

		// -(void)presentMessageCenterFromViewController:(UIViewController * _Nullable)viewController completion:(void (^ _Nullable)(BOOL))completion;
		[Export("presentMessageCenterFromViewController:completion:")]
		void PresentMessageCenter([NullAllowed] UIViewController viewController, [NullAllowed] Action<bool> completion);

		// -(void)presentMessageCenterFromViewController:(UIViewController * _Nullable)viewController withCustomData:(NSDictionary * _Nullable)customData;
		[Export("presentMessageCenterFromViewController:withCustomData:")]
		void PresentMessageCenter([NullAllowed] UIViewController viewController, [NullAllowed] NSDictionary customData);

		// -(void)presentMessageCenterFromViewController:(UIViewController * _Nullable)viewController withCustomData:(NSDictionary * _Nullable)customData completion:(void (^ _Nullable)(BOOL))completion;
		[Export("presentMessageCenterFromViewController:withCustomData:completion:")]
		void PresentMessageCenter([NullAllowed] UIViewController viewController, [NullAllowed] NSDictionary customData, [NullAllowed] Action<bool> completion);

		// @property (nonatomic) NSInteger unreadMessageCount;
		[Export("unreadMessageCount")]
		nint UnreadMessageCount { get; }

		// -(void)setRemoteNotificationDeviceToken:(NSData * _Nonnull)tokenData;
		[Export("setRemoteNotificationDeviceToken:")]
		void SetRemoteNotificationDeviceToken(NSData tokenData);

		// -(BOOL)didReceiveRemoteNotification:(NSDictionary * _Nonnull)userInfo fetchCompletionHandler:(void (^ _Nonnull)(UIBackgroundFetchResult))completionHandler __attribute__((warn_unused_result("")));
		[Export("didReceiveRemoteNotification:fetchCompletionHandler:")]
		bool DidReceiveRemoteNotification(NSDictionary userInfo, Action<UIBackgroundFetchResult> completionHandler);

		// -(BOOL)didReceveUserNotificationResponse:(UNNotificationResponse * _Nonnull)response withCompletionHandler:(void (^ _Nonnull)(void))completionHandler __attribute__((warn_unused_result("")));
		[Export("didReceveUserNotificationResponse:withCompletionHandler:")]
		bool DidReceveUserNotification(UNNotificationResponse response, Action completionHandler);

		// -(BOOL)willPresentNotification:(UNNotification * _Nonnull)notification withCompletionHandler:(void (^ _Nonnull)(UNNotificationPresentationOptions))completionHandler __attribute__((warn_unused_result("")));
		[Export("willPresentNotification:withCompletionHandler:")]
		bool WillPresentNotification(UNNotification notification, Action<UNNotificationPresentationOptions> completionHandler);

		// -(void)sendAttachmentText:(NSString * _Nonnull)text;
		[Export("sendAttachmentText:")]
		void SendAttachment(string text);

		// -(void)sendAttachmentImage:(UIImage * _Nonnull)image;
		[Export("sendAttachmentImage:")]
		void SendAttachment(UIImage image);

		// -(void)sendAttachmentFile:(NSData * _Nonnull)fileData withMimeType:(NSString * _Nonnull)mediaType;
		[Export("sendAttachmentFile:withMimeType:")]
		void SendAttachment(NSData fileData, string mimeType);

		// @property (copy, nonatomic) NSString * _Nullable personName;
		[NullAllowed, Export("personName")]
		string PersonName { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable personEmailAddress;
		[NullAllowed, Export("personEmailAddress")]
		string PersonEmailAddress { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable mParticleID;
		[NullAllowed, Export("mParticleID")]
		string MParticleID { get; set; }

		// -(void)removeCustomPersonDataWithKey:(NSString * _Nonnull)key;
		[Export("removeCustomPersonDataWithKey:")]
		void RemoveCustomPersonData(string key);

		// -(void)removeCustomDeviceDataWithKey:(NSString * _Nonnull)key;
		[Export("removeCustomDeviceDataWithKey:")]
		void RemoveCustomDeviceData(string key);

		// -(void)addCustomDeviceDataString:(NSString * _Nonnull)string withKey:(NSString * _Nonnull)key;
		[Export("addCustomDeviceDataString:withKey:")]
		void AddCustomDeviceData(string @string, string key);

		// -(void)addCustomDeviceDataNumber:(NSNumber * _Nonnull)number withKey:(NSString * _Nonnull)key;
		[Export("addCustomDeviceDataNumber:withKey:")]
		void AddCustomDeviceData(NSNumber number, string key);

		// -(void)addCustomDeviceDataBool:(BOOL)boolValue withKey:(NSString * _Nonnull)key;
		[Export("addCustomDeviceDataBool:withKey:")]
		void AddCustomDeviceData(bool boolValue, string key);

		// -(void)addCustomPersonDataString:(NSString * _Nonnull)string withKey:(NSString * _Nonnull)key;
		[Export("addCustomPersonDataString:withKey:")]
		void AddCustomPersonData(string @string, string key);

		// -(void)addCustomPersonDataNumber:(NSNumber * _Nonnull)number withKey:(NSString * _Nonnull)key;
		[Export("addCustomPersonDataNumber:withKey:")]
		void AddCustomPersonData(NSNumber number, string key);

		// -(void)addCustomPersonDataBool:(BOOL)boolValue withKey:(NSString * _Nonnull)key;
		[Export("addCustomPersonDataBool:withKey:")]
		void AddCustomPersonData(bool boolValue, string key);

		// -(void)dismissAllInteractions:(BOOL)animated;
		[Export("dismissAllInteractions:")]
		void DismissAllInteractions(bool animated);

		// @property (nonatomic) enum ApptentiveLogLevel logLevel;
		[Export("logLevel", ArgumentSemantic.Assign)]
		ApptentiveLogLevel LogLevel { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable distributionName;
		[NullAllowed, Export("distributionName")]
		string DistributionName { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable distributionVersion;
		[NullAllowed, Export("distributionVersion")]
		string DistributionVersion { get; set; }

		// - (void)logInWithToken:(NSString * _Nonnull)token completion:(void (^ _Nonnull)(BOOL, NSError * _Nullable))completion;
		[Export("logInWithToken:completion:")]
		void LogIn(string token, Action<bool, NSError> completion);

		// - (void)logOut;
		[Export("logOut")]
		void LogOut();

		// - (void)updateToken:(NSString * _Nonnull)token completion:(void (^ _Nullable)(BOOL))completion;
		[Export("updateToken:completion:")]
		void UpdateToken(string token, [NullAllowed] Action<bool> completion);

		[NullAllowed, Export("authenticationFailureCallback")]
		Action<ApptentiveAuthenticationFailureReason, string?> AuthenticationFailureCallback { get; set; }

	}

	// @interface ApptentiveConfiguration : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC13ApptentiveKit23ApptentiveConfiguration")]
	[DisableDefaultCtor]
	interface ApptentiveConfiguration
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull apptentiveKey;
		[Export("apptentiveKey")]
		string ApptentiveKey { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull apptentiveSignature;
		[Export("apptentiveSignature")]
		string ApptentiveSignature { get; }

		// @property (nonatomic) enum ApptentiveLogLevel logLevel;
		[Export("logLevel", ArgumentSemantic.Assign)]
		ApptentiveLogLevel LogLevel { get; set; }

		// @property (nonatomic) BOOL shouldSanitizeLogMessages __attribute__((deprecated("This property is ignored. Log messages will be redacted unless the app has a debugger attached.")));
		[Export("shouldSanitizeLogMessages")]
		bool ShouldSanitizeLogMessages { get; set; }

		// @property (copy, nonatomic) SWIFT_DEPRECATED_MSG("This property may take effect after the initial app information has been sent to the API.") NSString * distributionName __attribute__((deprecated("This property may take effect after the initial app information has been sent to the API.")));
		[Export("distributionName")]
		string DistributionName { get; set; }

		// @property (copy, nonatomic) SWIFT_DEPRECATED_MSG("This property may take effect after the initial app information has been sent to the API.") NSString * distributionVersion __attribute__((deprecated("This property may take effect after the initial app information has been sent to the API.")));
		[Export("distributionVersion")]
		string DistributionVersion { get; set; }

		// -(instancetype _Nullable)initWithApptentiveKey:(NSString * _Nonnull)apptentiveKey apptentiveSignature:(NSString * _Nonnull)apptentiveSignature;
		[Export("initWithApptentiveKey:apptentiveSignature:")]
		IntPtr Constructor(string apptentiveKey, string apptentiveSignature);
	}
}
