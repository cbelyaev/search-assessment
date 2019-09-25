using System;

namespace SearcherWebClient
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Core.Util;
    using IO.Swagger.Api;
    using IO.Swagger.Model;

    internal class Program
    {
        private const string BasePath = "http://localhost:5000/";
        private const int DefaultSize = 25;

        private static async Task Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Console.WriteLine($"Usage: {nameof(SearcherWebClient)} \"query\" [\"Market1[,Market2[,...]]\" [size]] ");
                return;
            }

            // parse arguments
            var query = args[0];
            var markets = args.Length > 1 ? args[1].ParseMarkets().ToList() : null;
            var size = args.Length > 2 ? ParseSize(args[2]) : (int?) null;
            var searchQueryDto = new SearchQueryDto(query, markets, size);

            // login
            var loginApi = new LoginApi(BasePath);
            var loginResult = await loginApi.LoginAsync(new UserLoginDto("user", "qwerty"));
            if (!string.IsNullOrEmpty(loginResult.ErrorMessage))
            {
                Console.WriteLine($"Login error: {loginResult.ErrorMessage}");
                return;
            }

            Console.WriteLine($"Login as {loginResult.User.Login} (id={loginResult.User.Id}) is successful");

            // search
            var searchApi = new SearchApi(BasePath)
            {
                Configuration =
                {
                    DefaultHeader = new Dictionary<string, string> {{"Authorization", "Bearer " + loginResult.Token}}
                }
            };
            var foundItems = await searchApi.SearchAsync(searchQueryDto);

            // show results
            foreach (var item in foundItems)
            {
                var sb = new StringBuilder($"{item.Id} ({item.ItemType}): {item.Name}");
                if (!string.IsNullOrEmpty(item.FormerName))
                {
                    sb.Append($" ({item.FormerName})");
                }

                sb.Append($" {item.Address}");
                Console.WriteLine(sb.ToString());
            }
        }

        private static int ParseSize(string text)
        {
            return int.TryParse(text, out var size) ? size : DefaultSize;
        }
    }
}
