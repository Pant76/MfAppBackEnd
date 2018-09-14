using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Hosting;
using System.Web.Http;

namespace MfAppBackend.Controllers
{
    public class ActivateProduct : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public string CheckCode(string code, string deviceId)
        {
            var csvFileName = "";
            var activationFileName = "";
            var codes = new List<string>();
            string csvPath = HostingEnvironment.MapPath("~/Uploads/") + Path.GetFileName(activationFileName);
            string activationFilePath = HostingEnvironment.MapPath("~/Uploads/") + Path.GetFileName(activationFileName);

            var res = File.ReadAllText(csvPath).Contains(code);
            if (!res)
                return "CodeNotValid";

            var rows = File.ReadAllLines(activationFilePath);
            foreach (var r in rows)
            {
                var cols = r.Split(',');
                var col = cols.FirstOrDefault(i => i == "free");
                if (col == null)
                    return "MaxExceeded";
                else
                    col = deviceId;
            }

            File.WriteAllLines(activationFilePath, rows);
            return "OK";
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}