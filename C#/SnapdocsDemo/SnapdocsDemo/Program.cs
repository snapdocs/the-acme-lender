using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Authentication.Model;
using Subscriptions.Model;
using System.Configuration;
using ClosingsAndDocs.Model;
using SnapdocsDemo.Authentication.Client;
using SnapdocsDemo.ClosingsAndDocs.Client;
using SnapdocsDemo.Subscriptions.Client;

namespace SnapdocsDemo
{
    class Program
    {
        private static readonly NameValueCollection AppSettings = ConfigurationManager.AppSettings;
        private static string _token = string.Empty;
        static void Main(string[] args)
        {
            SetToken().Wait();
            GetSubscriptions().Wait();
            CreateSampleClosing().Wait();
            Console.ReadLine();
        }

        static async Task SetToken()
        {
            var authClient = new AuthClient();
            var body = new OauthTokenBody(AppSettings["ClientId"], AppSettings["ClientSecret"], OauthTokenBody.GrantTypeEnum.Clientcredentials, AppSettings["Scope"]);

            try
            {
                _token = await authClient.GenerateToken(body);
                Console.WriteLine("Successfully retrieved the access token.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not retrieve auth token " + e.Message);
            }
        }

        static async Task GetSubscriptions()
        {
            var subscriptionsClient = new SubscriptionsClient(_token);
            try
            {
                var subscriptions = await subscriptionsClient.GetAllSubscriptions();
                Console.WriteLine($"Successfully retrieved {subscriptions.Data.Count} subscriptions:");

                foreach (var subscription in subscriptions.Data)
                {
                    Console.WriteLine(subscription.WebhookUrl);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static async Task CreateSampleClosing()
        {
            Borrower borrower1 = new Borrower("Sally", "Kate", "Signer", "Ms", "sally@gmail.com", "7815609235");
            ClosingUser closingUser1 = new ClosingUser("Kyra", "Closer", "7815468530", "kyra@gmail.com", new List<ClosingUser.RolesEnum>
                {
                    ClosingUser.RolesEnum.Closer
                });
            SettlementAgent setlementAgent1= new SettlementAgent("New", "Guy", "5678653450", "wFarrell@gmail.com");
            ExternalIdentifier externalIdentifier1 = new ExternalIdentifier(
                ExternalIdentifier.ExternalSystemEnum.Otherlos, ExternalIdentifier.ExternalTypeEnum.Filenumber, "1234");
            
            var body = new NewClosingStandard("123", "frb123", "frb_los", NewClosingStandard.SigningMethodEnum.WetOnly,
                new DateTime(2022, 1, 1), new DateTime(2024, 2, 3), new DateTime(2022, 2, 4), "2:30",
                "1000 Montgomery St", "San Fran", "CA", "94133", "funding@gmail.com", "1234 Fake St", "Springfield",
                "MA", "01906", "settlementofc@gmail.com", "Liggie", "5606 PGA Blvd. Suite 211", "Palm Beach Gardens",
                "FL", "33418", new List<string> {"isaac+closings@snapdocs.com"},
                new List<Borrower> {borrower1}, new List<ClosingUser> {closingUser1},
                new List<SettlementAgent> {setlementAgent1}, new List<ExternalIdentifier> {externalIdentifier1});

            var closingClient = new ClosingsClient(_token);

            try
            {
                var closing = await closingClient.CreateClosing(body);
                Console.WriteLine($"Successfully created a closing with uuid {closing.ClosingUuid} and SnapdocsUrl {closing.SnapdocsUrl}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }



        }

    }
}
