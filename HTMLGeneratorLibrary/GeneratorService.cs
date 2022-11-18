using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace HTMLGeneratorLibrary
{
    public class GeneratorService : IHtmlGeneratorService
    {
        private const string customTag = "{{";
        private const string customTagReversed = "}}";
        public string GetHTML(string template, object model)
        {
            //Пришли нулы
            if (string.IsNullOrEmpty(template))
                throw new ArgumentNullException("HtmlPage is null");
            if (!template.Contains($"{customTag}"))
                return template;
            if (model == null)
                throw new ArgumentNullException("Model is null");

            Type t = model.GetType();
            var args = t.GetProperties();

            var values = args.Select(value => $"{value.GetValue(model)}").ToArray();
            var agrsTypes = args.Select(x => x.Name).ToArray();
            //type : value
            var modelDict = new Dictionary<string, string> { };

            for (int i = 0; i<values.Length; i++)
            {
                modelDict.Add(agrsTypes[i], values[i]);
            }

            foreach (var modelItem in modelDict)
            {
                var temp = new string($"{customTag}variable.{modelItem.Key}{customTagReversed}");
                template = template.Replace($"{customTag}variable.{modelItem.Key}{customTagReversed}",modelItem.Value); 
            }

            return template;
        }

        public string GetHTML(Stream stream, object model)
        {
            throw new NotImplementedException();
        }

        public string GetHTML(byte[] bytes, object model)
        {
            string template = Encoding.ASCII.GetString(bytes);
            return GetHTML(template, model);
        }

        public byte[] GetHTMLToByte(string template, object model)
        {
            
            byte[] bytes = Encoding.ASCII.GetBytes(GetHTML(template,model));
            return bytes;
        }

        public byte[] GetHTMLToByte(Stream stream, object model)
        {
            throw new NotImplementedException();
        }

        public byte[] GetHTMLToByte(byte[] bytes, object model)
        {
            string template = Encoding.ASCII.GetString(bytes);
            return GetHTMLToByte(template,model);
        }

        public Stream GetHTMLToStream(string template, object model)
        {
            Stream stream = StringToStream(GetHTML(template, model));
            return stream ;

        }

        public Stream GetHTMLToStream(Stream stream, object model)
        {
            throw new NotImplementedException();
        }

        public Stream GetHTMLToStream(byte[] bytes, object model)
        {
            throw new NotImplementedException();
        }
        public static Stream StringToStream(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        //// convert string to stream
        ///А ЧТО ЮЗАТЬ? СТРИМ ИЛИ МЕМОРИ СТРИМ? 
        //string test = "Testing 1-2-3";
        //byte[] byteArray = Encoding.ASCII.GetBytes(test);
        //MemoryStream stream = new MemoryStream(byteArray);

        //// convert stream to string
        //StreamReader reader = new StreamReader(stream);
        //string text = reader.ReadToEnd();
    }
}
