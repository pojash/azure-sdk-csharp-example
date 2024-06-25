using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Storage;
using Azure.ResourceManager.Storage.Models;

class Program
{
    static async Task Main(string[] args)
    {
        // Define the subscription ID and resource group details
       // string subscriptionId = "b3371e36-ccf2-4e87-b2bd-f93452ebba34";
        string resourceGroupName = "my-sdk-rg";
      //  string storageAccountName = "himystorage7619";
        string location = "westus";

         // Authenticate the client
        var credential = new DefaultAzureCredential();
        //var armClient = new ArmClient(credential);
        ArmClient client = new ArmClient(new DefaultAzureCredential());

        
        // Create or get access to resource geoup
        SubscriptionResource subscription = await client.GetDefaultSubscriptionAsync();
        ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();
        ResourceGroupData resourceGroupData = new ResourceGroupData(location);
        ArmOperation<ResourceGroupResource> operation = await resourceGroups.CreateOrUpdateAsync(WaitUntil.Completed, resourceGroupName, resourceGroupData);


        Console.WriteLine($"Resource group '{resourceGroupName}' created.");

        
    }
}

