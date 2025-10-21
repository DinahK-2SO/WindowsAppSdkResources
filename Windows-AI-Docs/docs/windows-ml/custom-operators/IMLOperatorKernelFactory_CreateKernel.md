---
title: IMLOperatorKernelFactory.CreateKernel method
description: Creates an instance of the associated operator kernel, given information about the operator's usage within a model described in the provided context object.
ms.date: 4/1/2019
ms.topic: article
keywords: windows 10, windows machine learning, WinML, custom operators, CreateKernel
topic_type:
- APIRef
api_type:
- NA
api_name:
- IMLOperatorKernelFactory.CreateKernel
api_location:
- MLOperatorAuthor.h
---

# IMLOperatorKernelFactory.CreateKernel method

Creates an instance of the associated operator kernel, given information about the operator's usage within a model described in the provided context object.

```cpp
void CreateKernel(
    IMLOperatorKernelCreationContext* context,
    _COM_Outptr_ IMLOperatorKernel** kernel)
```

## Requirements

| | Requirement |
|-|-|
| **Minimum supported client** | Windows 10, build 17763 |
| **Minimum supported server** | Windows Server 2019 with Desktop Experience |
| **Header** | MLOperatorAuthor.h |

[!INCLUDE [help](../../includes/get-help.md)]
