# Deck of Cards
[![codecov](https://codecov.io/gh/Etn0bal/DeckOfCards/branch/master/graph/badge.svg?token=WP95IMQM8A)](https://codecov.io/gh/Etn0bal/DeckOfCards)

## Context

For this coding assignment I've decided to use a C# ASP.NET Web API project. This provides an easy method of usage/testing by doing HTTP requests.

## How to start the application

1. Download ASP.NET Core sdk from <https://dotnet.microsoft.com/download>.

2. Go in the src folder.

3. Restore the packages by doing  `dotnet restore`.

4. Build the solution by doing `dotnet build`.

5. Start the application by doing `dotnet run`.

The application should then be running `localhost:5000`.

## How to run the unit tests

1. If you haven't already, download ASP.NET Core sdk from <https://dotnet.microsoft.com/download>.

2. Go in the tests folder.

3. Restore the packages by doing  `dotnet restore`.

4. Build the solution by doing `dotnet build`.

5. Run the unit tests by doing  `dotnet test`.

See the test output in the console.

## API Usage

When the service is up and running, 3 endpoints are available. Here's the description of these endpoints :

- POST /Deck/Shuffle : Shuffle the deck of cards.
  
  200 if the shuffle worked.

  400 if there's no cards in the deck.

- GET /Deck/DealCard : Get the next card on top of the deck.
  
  200 with the card dealt.

  404 if there's no cards in the deck.

- POST /Deck/ChangeDeck : Change the current deck with a new one not shuffled.
  
  200 The deck has been changed.


We are taking for hypothesis that the service is running locally on `localhost:5000`. For example, you could do `localhost:5000/Deck/Shuffle` to shuffle the deck.

## Deployment (WIP)

This section is in work in progress since my Azure student account with Polytechnique didn't let me to automatically deploy the infrastructure and the service.

If you want to deploy manually to Azure you can. Use the provided terraform script in the feature/DeployToAzure branch in the DevOps folder. See terraform documentation: https://www.terraform.io/docs/index.html. You can then use this link to deploy the service to the web app created by the terraform file : https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/azure-apps/?view=aspnetcore-5.0&tabs=netcore-cli#deploy-the-app-self-contained
