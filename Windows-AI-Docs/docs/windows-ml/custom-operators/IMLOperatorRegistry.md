---
title: IMLOperatorRegistry interface
description: Represents an instance of a registry for the custom operator kernel and schema.
ms.date: 4/1/2019
ms.topic: article
keywords: windows 10, windows machine learning, WinML, custom operators, IMLOperatorRegistry
topic_type:
- APIRef
api_type:
- NA
api_name:
- IMLOperatorRegistry
api_location:
- MLOperatorAuthor.h
---

# IMLOperatorRegistry interface

Represents an instance of a registry for the custom operator kernel and schema. Custom operators may be used with Windows.AI.MachineLearning APIs by returning instances of **IMLOperatorRegistry** through **ILearningModelOperatorProviderNative**.

## Methods

| Name | Description |
|------|-------------|
| [RegisterOperatorKernel](IMLOperatorRegistry_RegisterOperatorKernel.md) | Registers a custom operator kernel. |
| [RegisterOperatorSetSchema](IMLOperatorRegistry_RegisterOperatorSetSchema.md) | Registers a set of custom operator schema comprising an operator set. |

## Requirements

| | Requirement |
|-|-|
| **Minimum supported client** | Windows 10, build 17763 |
| **Minimum supported server** | Windows Server 2019 with Desktop Experience |
| **Header** | MLOperatorAuthor.h |

[!INCLUDE [help](../../includes/get-help.md)]
