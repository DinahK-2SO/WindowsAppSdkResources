---
title: MLOperatorParameterOptions enum
description: Learn about the MLOperatorParameterOptions enum. This enum specifies option flags of input and output edges of operators.
ms.date: 4/1/2019
ms.topic: article
keywords: windows 10, windows machine learning, WinML, custom operators, MLOperatorParameterOptions
topic_type:
- APIRef
api_type:
- NA
api_name:
- MLOperatorParameterOptions
api_location:
- MLOperatorAuthor.h
---

# MLOperatorParameterOptions enum

Specifies option flags of input and output edges of operators. These options are used while defining custom operator schema.

## Fields

| Name | Value | Description |
|------|-------|-------------|
| Single | 0 | There is a single instance of the input or output. |
| Optional | 1 | The input or output may be omitted. |
| Variadic | 2 | The number of instances of the operator is variable. Variadic parameters must be last among the set of inputs or outputs. |

## Requirements

| | Requirement |
|-|-|
| **Minimum supported client** | Windows 10, build 17763 |
| **Minimum supported server** | Windows Server 2019 with Desktop Experience |
| **Header** | MLOperatorAuthor.h |

[!INCLUDE [help](../../includes/get-help.md)]
