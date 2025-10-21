---
title: MLOperatorSetId struct
description: Learn about the MLOperatorSetId struct, and its fields and requirements. This struct specifies the identity of an operator set.
ms.date: 4/1/2019
ms.topic: article
keywords: windows 10, windows machine learning, WinML, custom operators, MLOperatorSetId
topic_type:
- APIRef
api_type:
- NA
api_name:
- MLOperatorSetId
api_location:
- MLOperatorAuthor.h
---

# MLOperatorSetId struct

Specifies the identity of an operator set.

## Fields

| Name | Type | Description |
|------|------|-------------|
| domain | **const char*** | The domain of the operator, for example, "ai.onnx.ml", or an empty string for the ONNX domain. |
| version | **int32_t** | The version of the operator domain. |

## Requirements

| | Requirement |
|-|-|
| **Minimum supported client** | Windows 10, build 17763 |
| **Minimum supported server** | Windows Server 2019 with Desktop Experience |
| **Header** | MLOperatorAuthor.h |

[!INCLUDE [help](../../includes/get-help.md)]
