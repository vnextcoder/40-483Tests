using System;
using System.IO;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
using System.Threading;

namespace obser {
    class Program {
        static void Main (string[] args) {
            // Define a provider and two observers.
            LocationTracker provider = new LocationTracker ();
            LocationReporter reporter1 = new LocationReporter ("FixedGPS");
            reporter1.Subscribe (provider);
            LocationReporter reporter2 = new LocationReporter ("MobileGPS");
            reporter2.Subscribe (provider);

            provider.TrackLocation (new Location (47.6456, -122.1312));
            reporter1.Unsubscribe ();
            provider.TrackLocation (new Location (47.6677, -122.1199));
            provider.TrackLocation (null);
            provider.EndTransmission ();

            CancellationTokenSource Canxsource = new CancellationTokenSource ();
            var canc = Canxsource.Token;
            //var canc=new System.Threading.CancellationToken (false);

            var source = Observable.Range (1, 5)
                .Publish (a => {
                    a.Subscribe (Console.WriteLine);
                    return a;

                });
            source.RunAsync (canc);

            //source.ObserveOn

            var ad = source.Where (b => b < 4).Subscribe (ac => {
                    Console.WriteLine ($"ac is {ac}");
                  //  Canxsource.Cancel ();
                }

            );

            ad.Dispose ();
            
            //            var subcrtiption=source.Subscribe(i=> );

            //             var a = Observable.Using(
            //  () => new FileStream(@"d:\temp\test.txt", FileMode.Create),
            //  fs => Observable.Range(0, 10000)
            //  .Select(v => Encoding.ASCII.GetBytes(v.ToString()))

            //  .Subscribe();

            var xs = Observable.Create<string> (observer => {
                Console.WriteLine ("Side effect");
                observer.OnNext ("aaHi");
                observer.OnCompleted ();
                return Disposable.Empty;
            });
            var abc = xs.Publish (sharedXs => {
                sharedXs.Subscribe (Console.WriteLine);
                sharedXs.Subscribe (Console.WriteLine);
                sharedXs.Subscribe (
                    sb => Console.WriteLine ($"{sb} is {sb.Length}")
                );
                return sharedXs;
            });

            abc.RunAsync (new System.Threading.CancellationToken (false));

            //             var subscription = source.subscribe(
            //   function (x) { console.log('onNext: %s', x); },
            //   function (e) { console.log('onError: %s', e); },
            //   function () { console.log('onCompleted'); });

           //  Program2.Main2(null);

        }
    }
}