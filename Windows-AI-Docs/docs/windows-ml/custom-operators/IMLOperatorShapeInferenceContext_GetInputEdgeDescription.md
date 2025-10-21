---
title: IMLOperatorShapeInferenceContext.GetInputEdgeDescription method
description: Learn about the IMLOperatorShapeInferenceContext.GetInputEdgeDescription method. This method gets the description of the specified input edge of the operator.
ms.date: 4/1/2019
ms.topic: article
keywords: windows 10, windows machine learning, WinML, custom operators, GetInputEdgeDescription
topic_type:
- APIRef
api_type:
- NA
api_name:
- IMLOperatorShapeInferenceContext.GetInputEdgeDescription
api_location:
- MLOperatorAuthor.h
---

# IMLOperatorShapeInferenceContext.GetInputEdgeDescription method

Gets the description of the specified input edge of the operator.

```cpp
void GetInputEdgeDescription(
    uint32_t inputIndex,
    _Out_ MLOperatorEdgeDescription* edgeDescription)
```

## Requirements

| | Requirement |
|-|-|
| **Minimum supported client** | Windows 10, build 17763 |
| **Minimum supported server** | Windows Server 2019 with Desktop Experience |
| **Header** | MLOperatorAuthor.h |

[!INCLUDE [help](../../includes/get-help.md)]
