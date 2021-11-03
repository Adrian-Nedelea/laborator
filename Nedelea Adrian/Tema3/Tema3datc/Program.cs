using System;
using Google.Apis.Drive.v3;
using Google.Apis.Auth.OAuth2;
using System.Threading;
using Google.Apis.Util.Store;

namespace Tema3datc
{
    class Program
    {
        private static DriveService _service;

        private static string _token;
        static void Main(string[] args)
        {
            Initialize();
        }
        static void Initialize()
        {
            string[] scopes = new string[]
            {
                DriveService.Scope.Drive,
                DriveService.Scope.DriveFile

            };

            var clientId = "878490896478-2kfdh13lt3mg1mskua5v0gukfq1s705a.apps.googleusercontent.com";
            var clientSecret = "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";

            var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                new ClientSecrets
                {
                    ClientId = clientId,
                    ClientSecret = clientSecret
                },
                scopes,
                Environment.UserName,
                CancellationToken.None,

                new FileDataStore("Daimto.GoogleDrive.Auth.Store2")
            ).Result;

            _service = new DriveService(new Google.Apis.Services.BaseClientService.Initializer()
            {
                HttpClientInitializer = credential
            });

            _token = credential.Token.AccessToken;
            Console.Write("Token: " + credential.Token.AccessToken);
            GetMyFiles();
        }

        static void GetMyFiles()
        {
            var request=(HttpWebRequest)
        }
    }
}
