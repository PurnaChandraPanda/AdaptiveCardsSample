﻿# AdaptiveCardSample

Bot Framework v4 echo bot sample.

This bot has been created using [Bot Framework](https://dev.botframework.com), it shows how to create a simple bot that accepts input from the user and echoes it back.

## Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download) version 2.1

  ```bash
  # determine dotnet version
  dotnet --version
  ```
- Obtain your appid/ password from your respective `Bot Channels Regisration` or `Web App Bot`
- Create and update appsettings.json 
	```
	{
		"MicrosoftAppId": "your-registered-app-id",
		"MicrosoftAppPassword": "your-registered-app-password"
	}
	```

## To try this sample

- In a terminal, navigate to `AdaptiveCardSample`

    ```bash
    # change into project folder
    cd # AdaptiveCardSample
    ```

- Run the bot from a terminal or from Visual Studio, choose option A or B.

  A) From a terminal

  ```bash
  # run the bot
  dotnet run
  ```

  B) Or from Visual Studio

  - Launch Visual Studio
  - File -> Open -> Project/Solution
  - Navigate to `AdaptiveCardSample` folder
  - Select `AdaptiveCardSample.csproj` file
  - Press `F5` to run the project

## Testing the bot using Bot Framework Emulator

[Bot Framework Emulator](https://github.com/microsoft/botframework-emulator) is a desktop application that allows bot developers to test and debug their bots on localhost or running remotely through a tunnel.

- Install the Bot Framework Emulator version 4.3.0 or greater from [here](https://github.com/Microsoft/BotFramework-Emulator/releases)

### Connect to the bot using Bot Framework Emulator

- Launch Bot Framework Emulator
- File -> Open Bot
- Enter a Bot URL of `http://localhost:3978/api/messages`
- Create your .bot file
- Create ngrok uri via `ngrok`
- Update the .bot file with appid/ password/ ngrok uri

## Deploy the bot to Azure

To learn more about deploying a bot to Azure, see [Deploy your bot to Azure](https://aka.ms/azuredeployment) for a complete list of deployment instructions.

