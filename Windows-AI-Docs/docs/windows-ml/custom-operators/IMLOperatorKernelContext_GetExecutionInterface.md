---
title: IMLOperatorKernelContext.GetExecutionInterface method
description: Returns an object whose supported interfaces vary based on the kernel type. For the IMLOperatorKernelContext.GetExecutionInterface method.
ms.date: 4/1/2019
ms.topic: article
keywords: windows 10, windows machine learning, WinML, custom operators, GetExecutionInterface
topic_type:
- APIRef
api_type:
- NA
api_name:
- IMLOperatorKernelContext.GetExecutionInterface
api_location:
- MLOperatorAuthor.h
---

# IMLOperatorKernelContext.GetExecutionInterface method

Returns an object whose supported interfaces vary based on the kernel type. For kernels registered with [MLOperatorExecutionType::Cpu](MLOperatorExecutionType.md), *executionObject* will be set to **nullptr**. For kernels registered with **MLOperatorExecutionType::D3D12**, *executionObject* will support the [ID3D12GraphicsCommandList](/windows/desktop/api/d3d12/nn-d3d12-id3d12graphicscommandlist) interface. This may be a different object than was provided to [IMLOperatorKernelCreationContext::GetExecutionInterface](IMLOperatorKernelCreationContext_GetExecutionInterface.md) when the kernel instance was created.

```cpp
void GetExecutionInterface(
    _COM_Outptr_result_maybenull_ IUnknown** executionObject)
```

## Requirements

| | Requirement |
|-|-|
| **Minimum supported client** | Windows 10, build 17763 |
| **Minimum supported server** | Windows Server 2019 with Desktop Experience |
| **Header** | MLOperatorAuthor.h |

[!INCLUDE [help](../../includes/get-help.md)]
