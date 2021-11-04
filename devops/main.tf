provider "azurerm" {
  features {}
}

terraform {
    required_providers {
        azurerm = {
            source  = "hashicorp/azurerm"
            version = "~> 2.65"
        }
    }
}

resource "azurerm_resource_group" "DeckOfCardsAssignment" {
  name     = "deck-of-cards-assignment"
  location = "east us"
}

resource "azurerm_app_service_plan" "MainAppServicePlan" {
  name                = "main-app-service-plan"
  location            = azurerm_resource_group.DeckOfCardsAssignment.location
  resource_group_name = azurerm_resource_group.DeckOfCardsAssignment.name

  sku {
    tier = "Standard"
    size = "S1"
  }
}

resource "azurerm_app_service" "DeckOfCardsAppService" {
  name                = "deck-of-cards-app-service"
  location            = azurerm_resource_group.DeckOfCardsAssignment.location
  resource_group_name = azurerm_resource_group.DeckOfCardsAssignment.name
  app_service_plan_id = azurerm_app_service_plan.MainAppServicePlan.id

  site_config {
    dotnet_framework_version = "v4.0"
    scm_type                 = "LocalGit"
  }
}