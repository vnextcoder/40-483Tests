using System;
using System.Net;
using System.Text;
using FluentAssertions;
using Xbehave;
using Xunit;
namespace RayGunTest {
    public class Calculator {
        public int Add (int x, int y) => x + y;
    }

    public class CalculatorFeature {
        [Scenario]
        public void Addition (int a, int b, Calculator calculator, int answer) {

            "Given the number 1"

            .x (() => a = 1);

            "And the number 2"
            .x (() => b = 2);

            "And a calculator"
            .x (() => calculator = new Calculator ());

            "When I add the numbers together"
            .x (() => answer = calculator.Add (a, b));

            "Then the answer is 3"
            .x (() => Assert.Equal (3, answer));
        }

        // Simple assertion
        [Scenario]
        public void CreatingARequest (string url, HttpWebRequest request) {
            //var response=request.GetResponse();
            WebResponse response = default (WebResponse);
            string responsetext = "";
            "Given a valid HTTP URL"
            .x (() => url = "http://ifconfig.co/city");

            "When I create an HTTP web request"
            .x (() => request = (HttpWebRequest) WebRequest.Create (url));

            "And I fire request "
            .x (() => response = request.GetResponse ());

            "Then I lookup response Text "
            .x (() => {
                var encoding = ASCIIEncoding.ASCII;
                using (var reader = new System.IO.StreamReader (response.GetResponseStream (), encoding)) {
                    responsetext = reader.ReadToEnd ();

                    Console.WriteLine(":" + responsetext + ":");
                    responsetext=responsetext.Replace(Environment.NewLine,"" ).Trim();
                    Console.WriteLine(":" + responsetext + ":");
                }

            });

            "Then I check the City returned"
            .x (() => responsetext.Should ().BeEquivalentTo("Bengaluru"));
            // "Then the user agent is null"
            // .x (() => request.UserAgent.Should ().BeNull ());
        }
    }
}