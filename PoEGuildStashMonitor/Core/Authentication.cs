using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PoEGuildStashMonitor.Core
{
    public class Authentication : Singleton<Authentication>
    {
        public enum AuthType
        {
            Invalid,
            Poesessid
        }

        public event Action<bool> IsAuthenticatedChanged;

        public bool IsAuthenticated => current != AuthType.Invalid;

        private AuthType current = AuthType.Invalid;
        private string token = null;

        public void AuthenticatePoessid(string id)
        {
            current = AuthType.Poesessid;
            token = id;

            RaiseIsAuthenticatedChanged();
        }

        public void AddAuthHeader(HttpRequestMessage msg)
        {
            Debug.Assert(IsAuthenticated);

            switch(current)
            {
                case AuthType.Poesessid:
                    msg.Headers.Add("Cookie", $"POESESSID={token}");
                    break;
                default:
                    Debug.Assert(false, $"Unsupported authentication type {current}.");
                    break;
            }
        }

        public void InvalidateAuth()
        {
            current = AuthType.Invalid;
            RaiseIsAuthenticatedChanged();
        }

        private void RaiseIsAuthenticatedChanged()
        {
            IsAuthenticatedChanged?.Invoke(IsAuthenticated);
        }
    }
}
