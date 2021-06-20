using System;
using System.Net;
using System.Collections.Generic;

namespace FooderiaTycoon.IO
{
    public class Networking
    {
        private bool _isHost;
        private List<(Account account, IPAddress ipAddress, int port)> _clients;
        private List<int> _pings;
        private int _numberOfConnections;
        public Networking(List<(Account account, IPAddress ipAddress, int port)> ipAddresses, bool isHost)
        {
            _clients = ipAddresses;
            _isHost = isHost;
            _pings = new List<int>();
            _numberOfConnections = ipAddresses.Count;
            for (int i = 0; i < _numberOfConnections; i++)
                _pings.Add(0);
        }
        //TODO
        public bool IsHost => _isHost;
        public bool IsClient => !_isHost;
        public List<Account> Accounts => GetAccounts();
        public List<IPAddress> IpAddresses => GetIpAdresses();
        public List<int> Ports => GetPorts();
        public List<(IPAddress ipAddress, int port)> Connections => GetConnections();
        public List<(Account account, IPAddress ipAddress, int port)> ConnectionFull => _clients;
        public int NumberOfConnections => _numberOfConnections;

        private int GetConnectionPing(IPAddress ipAddress)
        {
            throw new NotImplementedException();
        }

        private int GetConnectionPing(IPAddress ipAddress, int port)
        {
            return GetConnectionPing(ipAddress);
        }
        
        private int GetConnectionPing((IPAddress ipAddress, int port) connection)
        {
            return GetConnectionPing(connection.ipAddress);
        }
        
        private int GetConnectionPing(int port, IPAddress ipAddress)
        {
            return GetConnectionPing(ipAddress);
        }
        
        private int GetConnectionPing((int port, IPAddress ipAddress) connection)
        {
            return GetConnectionPing(connection.ipAddress);
        }
        private int GetConnectionPing(Account account, IPAddress ipAddress, int port)
        {
            return GetConnectionPing(ipAddress);
        }
        
        private int GetConnectionPing((Account account, IPAddress ipAddress, int port) connection)
        {
            return GetConnectionPing(connection.ipAddress);
        }
        
        private int GetConnectionPing(Account account, int port, IPAddress ipAddress)
        {
            return GetConnectionPing(ipAddress);
        }
        
        private int GetConnectionPing((Account account, int port, IPAddress ipAddress) connection)
        {
            return GetConnectionPing(connection.ipAddress);
        }
        
        private int GetConnectionPing(int port, Account account, IPAddress ipAddress)
        {
            return GetConnectionPing(ipAddress);
        }
        
        private int GetConnectionPing((int port, Account account, IPAddress ipAddress) connection)
        {
            return GetConnectionPing(connection.ipAddress);
        }
        private int GetConnectionPing(int port, IPAddress ipAddress, Account account)
        {
            return GetConnectionPing(ipAddress);
        }
        
        private int GetConnectionPing((int port, IPAddress ipAddress, Account account) connection)
        {
            return GetConnectionPing(connection.ipAddress);
        }
        
        private int GetConnectionPing(IPAddress ipAddress, Account account, int port)
        {
            return GetConnectionPing(ipAddress);
        }
        
        private int GetConnectionPing((IPAddress ipAddress, Account account, int port) connection)
        {
            return GetConnectionPing(connection.ipAddress);
        }
        private int GetConnectionPing(IPAddress ipAddress, int port, Account account)
        {
            return GetConnectionPing(ipAddress);
        }
        
        private int GetConnectionPing((IPAddress ipAddress, int port, Account account) connection)
        {
            return GetConnectionPing(connection.ipAddress);
        }

        public List<IPAddress> GetIpAdresses()
        {
            List<IPAddress> ipAddresses = new List<IPAddress>();
            foreach ((Account account, IPAddress ipAddress, int port) in _clients)
                ipAddresses.Add(ipAddress);
            return ipAddresses;
        }

        public List<int> GetPorts()
        {
            List<int> ports = new List<int>();
            foreach ((Account account, IPAddress ipAddress, int port) in _clients)
                ports.Add(port);
            return ports;
        }

        public List<Account> GetAccounts()
        {
            List<Account> accounts = new List<Account>();
            foreach ((Account account, IPAddress ipAddress, int port) in _clients)
                accounts.Add(account);
            return accounts;
        }

        public List<(IPAddress ipAddress, int port)> GetConnections()
        {
            List<(IPAddress ipadress, int port)> connections = new List<(IPAddress ipadress, int port)>();
            foreach ((Account account, IPAddress ipAddress, int port) in _clients)
                connections.Add((ipAddress, port));
            return connections;
        }

        public void Update()
        {
            for (int i = 0; i < _numberOfConnections; i++)
                _pings[i] = GetConnectionPing(_clients[i]);
            throw new NotImplementedException();
        }

        private bool Connect()
        {
            throw new NotImplementedException();
        }

        private bool Disconnect()
        {
            throw new NotImplementedException();
        }

        public void SendInformation()
        {
            throw new NotImplementedException();
        }

        public void ReceiveInformation()
        {
            throw new NotImplementedException();
        }

        public static void CheckAvailableGames()
        {
            throw new NotImplementedException();
        }

        public bool InSync()
        {
            throw new NotImplementedException();
        }

        public void SyncUp()
        {
            throw new NotImplementedException();
        }
    }
}