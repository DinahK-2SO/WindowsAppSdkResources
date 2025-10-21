---
title: IMLOperatorKernel.Compute method
description: Learn about the IMLOperatorKernel.Compute method. This method computes the outputs of the kernel, and its implementation should be thread-safe.
ms.date: 4/1/2019
ms.topic: article
keywords: windows 10, windows machine learning, WinML, custom operators, Compute
topic_type:
- APIRef
api_type:
- NA
api_name:
- IMLOperatorKernel.Compute
api_location:
- MLOperatorAuthor.h
---

# IMLOperatorKernel.Compute method

Computes the outputs of the kernel. The implementation of this method should be thread-safe. The same instance of the kernel may be computed simultaneously on different threads.

```cpp
void Compute(
    IMLOperatorKernelContext* context)
```

## Requirements

| | Requirement |
|-|-|
| **Minimum supported client** | Windows 10, build 17763 |
| **Minimum supported server** | Windows Server 2019 with Desktop Experience |
| **Header** | MLOperatorAuthor.h |

[!INCLUDE [help](../../includes/get-help.md)]
