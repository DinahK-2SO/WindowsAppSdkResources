---
title: WinML native APIs
description: View the documentation for the WinML native APIs. See a list of the WinML native APIs with their syntax and descriptions.
ms.date: 4/1/2019
ms.topic: article
keywords: windows 10, windows machine learning, WinML
---

# WinML native APIs

The Windows Machine Learning native APIs are located in **windows.ai.machinelearning.native.h**.

## APIs

The following is a list of the WinML native APIs with their syntax and descriptions.

### Interfaces

| Name | Description |
|------|-------------|
| [ILearningModelDeviceFactoryNative](native-apis/ILearningModelDeviceFactoryNative.md) | Provides access to factory methods that enable the creation of [ILearningModelDevice](/uwp/api/windows.ai.machinelearning.learningmodeldevice) objects using [ID3D12CommandQueue](/windows/desktop/api/d3d12/nn-d3d12-id3d12commandqueue). |
| [ITensorNative](native-apis/ITensorNative.md) | Provides access to an [ITensor](/uwp/api/windows.ai.machinelearning.itensor) as an array of bytes or [ID3D12Resource](/windows/desktop/api/d3d12/nn-d3d12-id3d12resource) objects. |
| [ITensorStaticsNative](native-apis/ITensorStaticsNative.md) | Provides access to factory methods that enable the creation of [ITensor](/uwp/api/windows.ai.machinelearning.itensor) objects using [ID3D12Resource](/windows/desktop/api/d3d12/nn-d3d12-id3d12resource). |

### Structures

| Name | Description |
|------|-------------|
| [ILearningModelOperatorProviderNative](native-apis/ILearningModelOperatorProviderNative.md) | Provides access to [IMLOperatorRegistry](custom-operators/IMLOperatorRegistry.md) objects containing custom operator registrations. |

[!INCLUDE [help](../includes/get-help.md)]
