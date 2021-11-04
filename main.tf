provider "azurerm" {
  features {}
}

terraform {
    backend "azurerm" {
        resource_group_name  = "deck-of-cards-assignment"
        storage_account_name = "deckofcardsstorage"
        container_name       = "tf-storage"
        key                  = "terraform.tfstate"
    }
    required_providers {
        azurerm = {
            source  = "hashicorp/azurerm"
            version = "~> 2.65"
        }
    }
}

data "azurerm_resource_group" "DeckOfCardsAssignment" {
  name     = "deck-of-cards-assignment"
}

resource "azurerm_app_service_plan" "MainAppServicePlan" {
  name                = "main-app-service-plan"
  location            = data.azurerm_resource_group.DeckOfCardsAssignment.location
  resource_group_name = data.azurerm_resource_group.DeckOfCardsAssignment.name

  sku {
    tier = "Standard"
    size = "S1"
  }
}

resource "azurerm_app_service" "DeckOfCardsAppService" {
  name                = "deck-of-cards-app-service"
  location            = data.azurerm_resource_group.DeckOfCardsAssignment.location
  resource_group_name = data.azurerm_resource_group.DeckOfCardsAssignment.name
  app_service_plan_id = azurerm_app_service_plan.MainAppServicePlan.id

  site_config {
    dotnet_framework_version = "v4.0"
    scm_type                 = "LocalGit"
  }
}

output "AppServiceCredential" {
  value = azurerm_app_service.DeckOfCardsAppService.site_credential
}