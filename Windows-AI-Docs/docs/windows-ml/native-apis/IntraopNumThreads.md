---
title: IntraopNumThreads interface
description: Provides an ability to change the number of threads used in the threadpool for Intra Operator Execution for CPU operators through LearningModelSessionOptions.
ms.date: 10/14/2020
ms.topic: article
keywords: windows 10, windows machine learning, WinML, IntraopNumThreads
topic_type:
- APIRef
api_type:
- NA
api_name:
- IntraopNumThreads
api_location:
- windows.ai.machinelearning.native.h
---

# IntraopNumThreads interface

Provides an ability to change the number of threads used in the threadpool for Intra Operator Execution for CPU operators through [LearningModelSessionOptions](/uwp/api/windows.ai.machinelearning.learningmodelsessionoptions). By default, WinML sets the value as the maximum number of threads, which is the same number of logical cores on the user's CPU. Setting this value higher than the number of logical cores on the CPU may result in an inefficient threadpool and a slower evaluation.


## Sample code

```cpp
void SetIntraOpNumThreads(LearningModel model) {
    // Create LearningModelSessionOptions
    auto options = LearningModelSessionOptions();
    auto nativeOptions = options.as<ILearningModelSessionOptionsNative>();
 
    // Set the number of intra op threads to half of logical cores.
    uint32_t desiredThreads = std::thread::hardware_concurrency() / 2;
    nativeOptions->SetIntraOpNumThreadsOverride(desiredThreads);
 
    // Create session
    LearningModelSession session = nullptr;
    WINML_EXPECT_NO_THROW(session = LearningModelSession(model, LearningModelDeviceKind::Cpu, options));
}
```

## Requirements

| | Requirement |
|-|-|
| **Minimum supported client** | Windows 10, build 17763 |
| **Minimum supported server** | Windows Server 2019 with Desktop Experience |
| **Header** | windows.ai.machinelearning.native.h |

[!INCLUDE [help](../../includes/get-help.md)]
