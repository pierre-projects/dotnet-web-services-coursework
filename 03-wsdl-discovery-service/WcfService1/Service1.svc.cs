using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Text.RegularExpressions;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {


        // Extract URLs from common attributes
        private static readonly Regex AttrUrl =
            new Regex(@"\b(?:href|src|action)\s*=\s*['""](?<u>[^'""><\s]+)['""]",
                      RegexOptions.IgnoreCase | RegexOptions.Compiled);

        // Absolute URLs in plain text (fallback)
        private static readonly Regex PlainUrl =
            new Regex(@"\bhttps?://[^\s'""><)]+",
                      RegexOptions.IgnoreCase | RegexOptions.Compiled);

        private static bool LooksLikeWsdl(string u)
        {
            if (string.IsNullOrWhiteSpace(u)) return false;
            var s = u.Trim();
            return s.IndexOf(".wsdl", StringComparison.OrdinalIgnoreCase) >= 0
                || s.IndexOf("?wsdl", StringComparison.OrdinalIgnoreCase) >= 0;
        }

        public string[] getWsdlAddress(string url)
        {
            if (string.IsNullOrWhiteSpace(url)) return new string[0]; 

            string html;
            try
            {
                html = Download(url);
            }
            catch
            {
                return new string[0];
            }

            var fromAttrs = AttrUrl.Matches(html)
                                   .Cast<Match>()
                                   .Select(m => m.Groups["u"].Value);

            var fromPlain = PlainUrl.Matches(html)
                                    .Cast<Match>()
                                    .Select(m => m.Value);

            var candidates = fromAttrs.Concat(fromPlain);

            var result = NormalizeAndFilter(candidates, url)
                         .Distinct(StringComparer.OrdinalIgnoreCase)
                         .OrderBy(s => s, StringComparer.OrdinalIgnoreCase)
                         .ToArray();

            return result;
        }

        private static string Download(string uri)
        {
            using (var wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0";
                return wc.DownloadString(uri);
            }
        }

        private static IEnumerable<string> NormalizeAndFilter(IEnumerable<string> urls, string baseUrl)
        {
            if (!Uri.TryCreate(baseUrl, UriKind.Absolute, out var baseUri))
                yield break;

            foreach (var raw in urls)
            {
                if (string.IsNullOrWhiteSpace(raw)) continue;
                var r = raw.Trim();

                if (r.StartsWith("javascript:", StringComparison.OrdinalIgnoreCase)) continue;
                if (r.StartsWith("mailto:", StringComparison.OrdinalIgnoreCase)) continue;
                if (r.StartsWith("#")) continue;

                if (Uri.TryCreate(baseUri, r, out var abs))
                {
                    var s = abs.ToString();

                    // FIX: use Regex.Replace for case-insensitive replace on .NET Framework
                    s = Regex.Replace(s, "%3Fwsdl", "?wsdl", RegexOptions.IgnoreCase);

                    if (LooksLikeWsdl(s))
                        yield return s;
                }
            }

        }
    }
}
    

