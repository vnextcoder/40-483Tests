using System;
using WampSharp.V2;
//using WampSharp.V2.Realm;
using System.Threading.Tasks;
using SystemEx;
using WampSharp.V2.Client;
using WampSharp.V2.Rpc;
namespace Wampclient {
    class Program {
        static void Main (string[] args) {
            const string location = "ws://127.0.0.1:8080/";

            DefaultWampChannelFactory channelFactory = new DefaultWampChannelFactory ();

            IWampChannel channel = channelFactory.CreateJsonChannel (location, "realm1");

            IWampRealmProxy realmProxy = channel.RealmProxy;

            //await
            //channel.Open ();

            // Host WAMP application components

            Task openTask = channel.Open ();

            // await openTask;
            openTask.Wait (5000);


            Console.WriteLine("Press enter when a client finishes registering methods");
            Console.ReadLine();
            IArgumentsService proxy = channel.RealmProxy.Services.GetCalleeProxy<IArgumentsService> ();
            proxy.Ping ();
            Console.WriteLine ("Pinged!");

            int result = proxy.Add2 (2, 3);
            Console.WriteLine ("Add2: {0}", result);

            var starred = proxy.Stars ();
            Console.WriteLine ("Starred 1: {0}", starred);

            starred = proxy.Stars (nick: "Homer");
            Console.WriteLine ("Starred 2: {0}", starred);

            starred = proxy.Stars (stars: 5);
            Console.WriteLine ("Starred 3: {0}", starred);

            starred = proxy.Stars (nick: "Homer", stars : 5);
            Console.WriteLine ("Starred 4: {0}", starred);

            // string[] orders = proxy.Orders ("coffee");
            // Console.WriteLine ("Orders 1: {0}", string.Join (", ", orders));

            // orders = proxy.Orders ("coffee", limit : 10);
            // Console.WriteLine ("Orders 2: {0}", string.Join (", ", orders));

            Console.ReadLine ();

        }
    }
    public interface IArgumentsService {
        [WampProcedure ("com.arguments.ping")]
        void Ping ();

        [WampProcedure ("com.arguments.add2")]
        int Add2 (int a, int b);

        [WampProcedure ("com.arguments.stars")]
        string Stars (string nick = "somebody", int stars = 0);
    }

    // public class ArgumentsService : IArgumentsService
    // {
    //     public void Ping()
    //     {
    //     }

    //     public int Add2(int a, int b)
    //     {
    //         return a + b;
    //     }

    //     public string Stars(string nick = "somebody", int stars = 0)
    //     {
    //         return string.Format("{0} starred {1}x", nick, stars);
    //     }
    // }

}