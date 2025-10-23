# Windows AI APIs: Win32 Exception When Passing Null ContentFilterOptions

## Issue Description
When calling Windows AI imaging APIs like `ImageDescriptionGenerator.DescribeAsync()`, you may encounter a Win32 exception if you pass `null` for the `ContentFilterOptions` parameter.

## Error Symptoms
- Win32 exception thrown during `DescribeAsync()` call
- App crashes or shows unhandled exception dialog
- The AI model initializes successfully, but fails during actual  processing
- Exception occurs specifically when describing images, not during model loading

## Root Cause
The Windows AI imaging APIs require a valid `ContentFilterOptions` object to configure content safety settings. Passing `null` causes an internal Win32 exception in the AI service because the API cannot properly configure content moderation without this parameter.

## Solution
Always pass a valid `ContentFilterOptions` object instead of `null`:

**❌ Problematic (causes Win32 exception):**
```csharp
var modelResponse = await Session.DescribeAsync(inputImage, ImageDescriptionKind.BriefDescription, null);
```

**✅ Fixed (works correctly):**
```csharp
using Microsoft.Windows.AI.ContentSafety;

ContentFilterOptions filterOptions = new();
var modelResponse = await Session.DescribeAsync(inputImage, ImageDescriptionKind.BriefDescription, filterOptions);
```

## Complete Working Example
```csharp
using Microsoft.Graphics.Imaging;
using Microsoft.Windows.AI;
using Microsoft.Windows.AI.Imaging;
using Microsoft.Windows.AI.ContentSafety;
using System;
using System.Threading.Tasks;

public async Task<string> DescribeImage(ImageBuffer inputImage)
{
    // Create ContentFilterOptions with default settings
    ContentFilterOptions filterOptions = new();
    
    // Optional: Configure specific content filtering levels
    // filterOptions.PromptMinSeverityLevelToBlock.ViolentContentSeverity = SeverityLevel.Medium;
    // filterOptions.ResponseMinSeverityLevelToBlock.ViolentContentSeverity = SeverityLevel.Medium;
    
    var modelResponse = await imageDescriptionGenerator.DescribeAsync(
        inputImage, 
        ImageDescriptionKind.BriefDescription, 
        filterOptions);  // Never pass null here
        
    if (modelResponse.Status != ImageDescriptionResultStatus.Complete)
    {
        return $"Image description failed with status: {modelResponse.Status}";
    }
    
    return modelResponse.Description;
}
```

## Required Using Statements
Make sure to include the ContentSafety namespace:
```csharp
using Microsoft.Windows.AI.ContentSafety;
```

## Default vs Custom Content Filtering
You can use default settings or configure specific content filtering:

**Default settings (recommended for most cases):**
```csharp
ContentFilterOptions filterOptions = new();
```

**Custom content filtering:**
```csharp
ContentFilterOptions filterOptions = new();
filterOptions.PromptMinSeverityLevelToBlock.ViolentContentSeverity = SeverityLevel.Medium;
filterOptions.PromptMinSeverityLevelToBlock.HateSeverity = SeverityLevel.Low;
filterOptions.ResponseMinSeverityLevelToBlock.ViolentContentSeverity = SeverityLevel.Medium;
filterOptions.ResponseMinSeverityLevelToBlock.HateSeverity = SeverityLevel.Low;
```

## Related APIs
This issue affects all image description methods:
- `ImageDescriptionGenerator.DescribeAsync()`
- Any custom wrapper methods that call the underlying DescribeAsync API
