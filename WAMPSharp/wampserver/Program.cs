using System;
using System.Threading.Tasks;
using SystemEx;
using WampSharp.V2;
using WampSharp.V2.Realm;
using WampSharp.V2.Rpc;

namespace wampserver {
    class Program {
        static void Main (string[] args) {
            const string location = "ws://127.0.0.1:8080/";
            using (IWampHost host = new DefaultWampHost (location)) {
                IWampHostedRealm realm = host.RealmContainer.GetRealmByName ("realm1");

                // Host WAMP application components

                IArgumentsService instance = new ArgumentsService ();


                Task<IAsyncDisposable> registrationTask = realm.Services.RegisterCallee (instance);
                // await registrationTask;
                registrationTask.Wait ();

                host.Open ();

                Console.WriteLine ("Server is running on " + location);
                Console.ReadLine ();
            }

        }
    }
    public class ArgumentsService : IArgumentsService {
        public void Ping () { }

        public int Add2 (int a, int b) {
            return a + b;
        }

        public string Stars (string nick = "somebody", int stars = 0) {
            return string.Format ("{0} starred {1}x", nick, stars);
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

}