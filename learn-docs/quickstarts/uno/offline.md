---
title: Add offline data sync to your Uno Platform app
description: Add offline data sync to your Uno Platform app using Azure Mobile Apps with our tutorial.
author: adrianhall
ms.service: mobile-services
ms.topic: article
ms.date: 05/03/2023
ms.author: adhal
---

# Add offline data sync to your Uno Platform app

This tutorial covers the offline sync feature of Azure Mobile Apps for the Uno Platform quickstart app. Offline sync allows end users to interact with a mobile app&mdash;viewing, adding, or modifying data&mdash;even when there's no network connection. Changes are stored in a local database. Once the device is back online, these changes are synced with the remote backend.

Before starting this tutorial, you should have completed the [Uno Platform Quickstart Tutorial](./index.md), which includes creating a suitable backend service.  We also assume you have [added authentication](./authentication.md) to your application.  You can add offline capabilities to your app without authentication.

## Update the app to support offline sync

In online operation, you read to and write from a `IRemoteTable<T>`.  When using offline sync, you read to and write from a `IOfflineTable<T>` instead.  The `IOfflineTable<T>` uses an on-device SQLite database which you synchronize with a remote service.

### Add the necessary NuGet packages

[!INCLUDE[Instructions for adding the offline NuGet Packages.](~/mobile-apps/azure-mobile-apps/includes/quickstart/windows/add-offline-nuget.md)]

[!INCLUDE[Instructions for altering the code to support offline.](~/mobile-apps/azure-mobile-apps/includes/quickstart/windows/add-offline-code.md)]

### Set the offline database location

In the `TodoApp.Uno` project, edit the `MainPage.xaml.cs` file. Change the definition of the `RemoteTodoService` as follows:

``` csharp
_service = new RemoteTodoService(async () => await GetAuthenticationToken())
{
    OfflineDb = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/offline.db"
};
```

If you haven't completed the [authentication tutorial](./authentication.md), the definition should look like this instead:

``` csharp
_service = new RemoteTodoService()
{
    OfflineDb = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/offline.db"
};
```

> [!NOTE]
> You can store the offline database wherever you have read/write/create permissions on a Windows system.  The `Environment.SpecialFolder` class gives standard locations according to the application.

[!INCLUDE [Instructions for testing offline mode.](~/mobile-apps/azure-mobile-apps/includes/quickstart/common/test-offline-app.md)]

[!INCLUDE [Instructions to clean up resources.](~/mobile-apps/azure-mobile-apps/includes/quickstart/common/clean-up.md)]

## Next steps

* Review the HOW TO documentation:
  * [ASP.NET6 service documentation](~/mobile-apps/azure-mobile-apps/howto/server/dotnet-core.md)
  * [.NET client documentation](~/mobile-apps/azure-mobile-apps/howto/client/dotnet.md)
