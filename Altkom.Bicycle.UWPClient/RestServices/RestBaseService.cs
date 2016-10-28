using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Bicycle.UWPClient.RestServices
{
    public abstract class RestBaseService<TItem>
    {
        public async Task<IList<TItem>> GetListAsync(string request)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(request);

                return await response.Content.ReadAsAsync<IList<TItem>>();
            }
        }

    }
}
