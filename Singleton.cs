using System;
using System.Collections.Generic;
using System.Threading;

namespace GangOfFour.Singleton.RealWorld {

    /// <summary>
    /// MainApp startup class for Real-World  /// Singleton Design Pattern.
    /// </summary>
    class MainApp {

        /// <summary>
        /// Entry point into console application.
        /// </summary>
        static void Main () {
            LoadBalancer b1 = LoadBalancer.GetLoadBalancer ();
            LoadBalancer b2 = LoadBalancer.GetLoadBalancer ();
            LoadBalancer b3 = LoadBalancer.GetLoadBalancer ();
            LoadBalancer b4 = LoadBalancer.GetLoadBalancer ();

            // Same instance?
            if (b1 == b2 && b2 == b3 && b3 == b4) {
                Console.WriteLine ("Същата инстанция\n");
            }
            
            // Load balance 15 server requests
            LoadBalancer balancer = LoadBalancer.GetLoadBalancer ();
            for (int i = 0; i < 15; i++) {
                string server = balancer.Server;
                Console.WriteLine ("Изпрати заявка към: " + server);
            }

            // Wait for user
            Console.ReadKey ();
        }
    }

    /// <summary>
    /// The 'Singleton' class
    /// </summary>
    class LoadBalancer {
        private static LoadBalancer _instance;
        private List<string> _servers = new List<string> ();
        private Random _random = new Random ();

        // Lock synchronization object
        private static object syncLock = new object ();

        // Constructor (protected)
        protected LoadBalancer () {

            // List of available servers
            _servers.Add ("Сървър 1");
            _servers.Add ("Сървър 2");
            _servers.Add ("Сървър 3");
            _servers.Add ("Сървър 4");
            _servers.Add ("Сървър 5");
        }

        public static LoadBalancer GetLoadBalancer () {

            // Support multithreaded applications through
            // 'Double checked locking' pattern which (once
            // the instance exists) avoids locking each
            // time the method is invoked
            if (_instance == null) {
                lock (syncLock) {
                    if (_instance == null) {
                        _instance = new LoadBalancer ();
                    }
                }
            }
            return _instance;
        }

        // Simple, but effective random load balancer
        public string Server {
            get {
                int r = _random.Next (_servers.Count);
                return _servers[r].ToString ();
            }
        }
    }
}