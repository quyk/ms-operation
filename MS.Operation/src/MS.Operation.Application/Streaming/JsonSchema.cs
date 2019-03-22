using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace MS.Operation.Application.Streaming
{
    public static class JsonSchema <T>
    {
        private static string OpenSchema(string file)
        {
            var assemblyPath = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
            var directoryPath = Path.GetDirectoryName(assemblyPath);
            return Path.Combine(directoryPath, $"Validations\\{file}");
        }

        public static (bool valid, IList<string> mesage) IsValid(T obj, string schemaFile)
        {
            using (var file = File.OpenText(OpenSchema(schemaFile)))
            using (var reader = new JsonTextReader(file))
            {
                var json = JsonConvert.SerializeObject(obj);
                var jsonObject = JObject.Parse(json);
                var schema = JSchema.Load(reader);
                var valid = jsonObject.IsValid(schema, out IList<string> mesage);

                return (valid, mesage);
            }
        }
    }
}
