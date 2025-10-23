# Windows AI APIs: "Not declared by app" Error with Correct systemAIModels Capability

## Issue Description
When using Windows AI imaging APIs (ImageDescriptionGenerator, ImageScaler, etc.), you may encounter a "Not declared by app" error even when your `Package.appxmanifest` correctly declares the `systemAIModels` capability.

## Error Symptoms
- `ImageDescriptionGenerator.GetReadyState()` throws a `COMException`
- Error message indicates the capability is "Not declared by app"
- The `systemAIModels` capability is properly declared in the manifest

## Root Cause
The issue occurs when the `MaxVersionTested` attribute in your `Package.appxmanifest` is set to an older Windows version that doesn't support Windows AI features. Even with the correct capability declared, Windows treats the app as incompatible with AI features if the manifest indicates it was only tested on older versions.

## Solution
Update the `MaxVersionTested` attribute in your `Package.appxmanifest` to a recent Windows version that supports Windows AI features:

**❌ Problematic (causes "Not declared by app" error):**
```xml
<Dependencies>
  <TargetDeviceFamily Name="Windows.Universal" MinVersion="10.0.17763.0" MaxVersionTested="10.0.19041.0" />
  <TargetDeviceFamily Name="Windows.Desktop" MinVersion="10.0.17763.0" MaxVersionTested="10.0.19041.0" />
</Dependencies>
```

**✅ Fixed (allows Windows AI APIs to work):**
```xml
<Dependencies>
  <TargetDeviceFamily Name="Windows.Universal" MinVersion="10.0.17763.0" MaxVersionTested="10.0.26226.0" />
  <TargetDeviceFamily Name="Windows.Desktop" MinVersion="10.0.17763.0" MaxVersionTested="10.0.26226.0" />
</Dependencies>
```

## Complete Manifest Requirements
Ensure your manifest includes both the capability AND the updated version:

```xml
<Package
  xmlns="http://schemas.microsoft.com/appx/manifest/foundation/windows10"
  xmlns:systemai="http://schemas.microsoft.com/appx/manifest/systemai/windows10"
  IgnorableNamespaces="uap rescap systemai">

  <Dependencies>
    <TargetDeviceFamily Name="Windows.Universal" MinVersion="10.0.17763.0" MaxVersionTested="10.0.26226.0" />
    <TargetDeviceFamily Name="Windows.Desktop" MinVersion="10.0.17763.0" MaxVersionTested="10.0.26226.0" />
  </Dependencies>

  <Capabilities>
    <rescap:Capability Name="runFullTrust" />
    <systemai:Capability Name="systemAIModels" />
  </Capabilities>
</Package>
```

## Why This Happens
- Windows AI features require newer Windows versions
- The `MaxVersionTested` attribute tells Windows what version your app was designed for
- When set to older versions (like 10.0.19041.0 = Windows 10 2004), Windows assumes your app doesn't support newer features
- This causes the system to reject access to Windows AI APIs even with correct capabilities

## Verification
After updating your manifest:
1. `ImageDescriptionGenerator.GetReadyState()` should no longer throw exceptions
2. The app should properly initialize Windows AI models

## Related APIs
This issue affects all Windows AI APIs including:
- `ImageDescriptionGenerator`
- `ImageScaler`
- `ImageObjectExtractor`
- `ImageObjectRemover`
- `TextRecognizer`