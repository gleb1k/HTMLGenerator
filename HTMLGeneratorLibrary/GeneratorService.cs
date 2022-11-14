using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLGeneratorLibrary
{
    public class GeneratorService : IHtmlGeneratorService
    {
        private const string customTag = "{{";
        public string GetHTML(string template, object model)
        {
            //Пришли нулы
            if (string.IsNullOrEmpty(template))
                return "";
            if (!template.Contains($"{customTag}"))
                return ""; 
            if (model == null)
                return template.Replace("{{result}}", null);
            return template.Replace("{{result}}",model.ToString());
        }

        public string GetHTML(Stream stream, object model)
        {
            throw new NotImplementedException();
        }

        public string GetHTML(byte[] bytes, object model)
        {
            throw new NotImplementedException();
        }

        public byte[] GetHTMLToByte(string template, object model)
        {
            throw new NotImplementedException();
        }

        public byte[] GetHTMLToByte(Stream stream, object model)
        {
            throw new NotImplementedException();
        }

        public byte[] GetHTMLToByte(byte[] bytes, object model)
        {
            throw new NotImplementedException();
        }

        public Stream GetHTMLToStream(string template, object model)
        {
            throw new NotImplementedException();
        }

        public Stream GetHTMLToStream(Stream stream, object model)
        {
            throw new NotImplementedException();
        }

        public Stream GetHTMLToStream(byte[] bytes, object model)
        {
            throw new NotImplementedException();
        }
    }
}
