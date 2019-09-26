using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TinyUrl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            string url = "google.com";
            try
            {

                if (url.Length <= 30)
                {
                    return url;
                }
                if (!url.ToLower().StartsWith("http") && !url.ToLower().StartsWith("ftp"))
                {
                    url = "http://" + url;
                }
                var request = WebRequest.Create("http://tinyurl.com/api-create.php?url=" + url);

                var res = request.GetResponse();
                string text;
                using (var reader = new StreamReader(res.GetResponseStream()))
                {
                    text = reader.ReadToEnd();
                }
                return text;
            }
            catch (Exception)
            {
                return url;
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(bool? value)
        {
            try
            {

                Task.Run(() => TestMethod());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return "value";
        }


        // GET api/values/int/5
        [HttpGet("int/{id}")]
        public ActionResult<int> Get(int? id)

        {
            try
            {                                                                                                                                                                                                                                                                                                                                                                                                                                                       
                var task = new Task(() => TestMethod());
                task.Start();
                task.GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return -1;
        }

        // POST api/values 
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        public  int TestMethod()
        {
            Console.WriteLine(" Task satrted");
            int x = 5;
            while(x ==5)
            {

            }
            
            return 1;
        }
    }
}
